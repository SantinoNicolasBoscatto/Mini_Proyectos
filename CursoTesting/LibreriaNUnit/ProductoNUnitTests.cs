using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [TestFixture]
    public class ProductoNUnitTests
    {
        [Test]
        public void GetPrecio_InputClientePremium_ReturnPrice80()
        {
            Producto producto = new Producto { Precio = 100};

            // Creo el Mock
            var mockCliente = new Mock<ICliente>();
            // Con Setup() puedo setear valores a las propiedades del objeto del mock
            mockCliente.Setup(x => x.IsPremium).Returns(true);

            var precioDescuento = producto.GetPrecio(mockCliente.Object);
            Assert.That(precioDescuento, Is.EqualTo(80));
        }
    }
}
