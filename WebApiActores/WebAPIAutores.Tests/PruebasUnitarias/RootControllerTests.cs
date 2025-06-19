using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiActores.Controllers.V1;
using WebAPIAutores.Tests.Mocks;
using Moq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIAutores.Tests.PruebasUnitarias
{
    [TestClass]
    public class RootControllerTests
    {
        [TestMethod]
        public async Task SiEsAdmin_Devolver5URL()
        {
            //Preparacion
            var authorizationServiceMock = new AuthorizationServiceSuccessMock();
            var urlHelperMock = new UrlHelperMock();
            var rootController = new RootController(authorizationServiceMock);
            rootController.Url = new UrlHelperMock();
            //Ejecucion
            var resultado = await rootController.Get();

            //Verificacion
            Assert.AreEqual(5, resultado.Value!.Count());
        }

        [TestMethod]
        public async Task NoAdmin_Devolver3URL()
        {
            //Preparacion
            var authorizationServiceMock = new AuthorizationServiceFailedMock();
            var urlHelperMock = new UrlHelperMock();
            var rootController = new RootController(authorizationServiceMock);
            rootController.Url = new UrlHelperMock();
            //Ejecucion
            var resultado = await rootController.Get();

            //Verificacion
            Assert.AreEqual(3, resultado.Value!.Count());
        }


        [TestMethod]
        public async Task NoAdmin_Devolver3URL_ConMOQ()
        {
            //Preparacion Con Mocks
            var mockAuthorization = new Mock<IAuthorizationService>();
            mockAuthorization.Setup(x => x.AuthorizeAsync
            (It.IsAny<ClaimsPrincipal>(), It.IsAny<object>(), It.IsAny<IEnumerable<IAuthorizationRequirement>>()))
            .Returns(Task.FromResult(AuthorizationResult.Failed()));
            mockAuthorization.Setup(x => x.AuthorizeAsync
            (It.IsAny<ClaimsPrincipal>(), It.IsAny<object>(), It.IsAny<string>()))
            .Returns(Task.FromResult(AuthorizationResult.Failed()));

            var mockUrl = new Mock<IUrlHelper>();
            mockUrl.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("");


            var rootController = new RootController(mockAuthorization.Object);
            rootController.Url = mockUrl.Object;

            //Ejecucion
            var resultado = await rootController.Get();

            //Verificacion
            Assert.AreEqual(3, resultado.Value!.Count());
        }
    }
}
