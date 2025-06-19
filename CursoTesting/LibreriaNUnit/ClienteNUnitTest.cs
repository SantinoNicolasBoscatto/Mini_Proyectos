using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente cliente = null!;
        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
        }
        [Test]
        public void CrearNombre_InputDosString_ReturnNombreCompleto()
        {
            var nombreCompleto = cliente.CrearNombre("Santino", "Boscatto");

            Assert.Multiple(() =>
            {
                // Con contain verifico que almenos ese texto se encuentre en la cadena, IgnoreCase ignora las 
                // Mayusculas y minusculas.
                Assert.That(nombreCompleto, Does.Contain("Santino").IgnoreCase);
                // Evalua que empiece con ciertos caracteres
                Assert.That(nombreCompleto, Does.StartWith("S"));
                // Evalua que termine con ciertos caracteres
                Assert.That(nombreCompleto, Does.EndWith("o"));
            });
        }
        [Test]
        public void ClientNombre_NoValues_ReturnNull()
        {
            Assert.That(cliente.ClienteNombre, Is.Null);
        }
        [Test]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;
            Assert.That(descuento, Is.InRange(5, 24));
        }
        [Test]
        public void CrearNombre_InputNombreEmpty_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => cliente.CrearNombre("", "Boscatto"));
            Assert.That(() => cliente.CrearNombre("", "Boscatto"), Throws.ArgumentException);
        }

        [Test] // Si no tengo parametros puedo detallar la logica de mi funcion
        public void GetClienteDetalle_CrearClienteMenos500OrderTotal_ReturnClienteBasico()
        {
            cliente.OrderTotal = 150;
            var result = cliente.GetClienteDetalle();
            // Puedo evaluar el tipo de dato de mi resultado
            Assert.That(result, Is.TypeOf<ClienteBasico>());
        }
    }
}
