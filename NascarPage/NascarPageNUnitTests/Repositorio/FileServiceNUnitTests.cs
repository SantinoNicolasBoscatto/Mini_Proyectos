using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using NascarPage;
using NascarPageNUnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NascarPageNUnitTests.Repositorio
{
    public class FileServiceNUnitTests
    {
        private IFilesService fileService = null!;
        private IFormFile file = null!;
        private Mock<IWebHostEnvironment> webRootMock = null!;
        private Piloto Prueba = null!;


        [SetUp]
        public void Setup()
        {
            var httpContextMock = new Mock<IHttpContextAccessor>();
            httpContextMock.SetupAllProperties();
            httpContextMock.Object.HttpContext = new DefaultHttpContext();

            webRootMock = new Mock<IWebHostEnvironment>();
            webRootMock.SetupAllProperties();
            webRootMock.Object.WebRootPath = "C:\\Users\\Santino\\source\\repos\\NascarPage\\NascarPage\\wwwroot";

            var content = "Hello, this is a test file.";
            var fileName = "test.txt";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            var formFileMock = new Mock<IFormFile>(); formFileMock.Setup(_ => _.FileName).Returns(fileName);
            formFileMock.Setup(_ => _.Length).Returns(stream.Length);
            formFileMock.Setup(_ => _.OpenReadStream()).Returns(stream);
            formFileMock.Setup(_ => _.ContentDisposition).Returns($"inline; filename={fileName}");
            formFileMock.Setup(_ => _.ContentType).Returns("text/plain");
            file = formFileMock.Object;

            fileService = new FilesService(webRootMock.Object, httpContextMock.Object);
        }

        [Test]
        public async Task GuardarImagen_ReturnsString()
        {
            var url = await fileService.GuardarImagen("carpeta", file);
            Assert.That(url, Is.Not.Null);
            Assert.That(url, Is.Not.Empty);
            url = webRootMock.Object.WebRootPath + url.Replace(":", "");
            Assert.That(File.Exists(url), Is.True);

        }
        [Test]
        public async Task Borrar_FileExists_FileDeleted()
        { 
            var carpeta = "carpeta";
            var fileName = "testfile.txt";
            var filePath = Path.Combine(webRootMock.Object.WebRootPath, carpeta, fileName);
            if (!Directory.Exists(Path.Combine(webRootMock.Object.WebRootPath, carpeta))) Directory.CreateDirectory(Path.Combine(webRootMock.Object.WebRootPath, carpeta));
            File.Create(filePath).Dispose();
            await fileService.Borrar(filePath, carpeta);
            Assert.That(File.Exists(filePath), Is.False);
        }
    }
}
