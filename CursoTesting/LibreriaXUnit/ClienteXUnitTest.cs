using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Libreria
{
    public class ClienteXUnitTest
    {
        [Fact]
        public void CrearNombre_InputDosString_ReturnNombreCompleto()
        {
            var cliente = new Cliente();
            var nombreCompleto = cliente.CrearNombre("Santino", "Boscatto");

            Assert.Multiple(() =>
            {
                Assert.Contains("Santino", nombreCompleto);
                Assert.StartsWith("S", nombreCompleto);
                Assert.EndsWith("o", nombreCompleto);
            });
        }
        [Fact]
        public void ClientNombre_NoValues_ReturnNull()
        {
            var cliente = new Cliente();
            Assert.Null(cliente.ClienteNombre);
        }
        [Fact]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsDescuentoIntervalo()
        {
            var cliente = new Cliente();
            int descuento = cliente.Descuento;
            Assert.InRange(descuento,5,24);
        }
        [Fact]
        public void CrearNombre_InputNombreEmpty_ThrowException()
        {
            var cliente = new Cliente();
            Assert.Throws<ArgumentException>(() => cliente.CrearNombre("", "Boscatto"));
        }
        [Fact]
        public void GetClienteDetalle_CrearClienteMenos500OrderTotal_ReturnClienteBasico()
        {
            var cliente = new Cliente();
            cliente.OrderTotal = 150;
            var result = cliente.GetClienteDetalle();
            Assert.IsType<ClienteBasico>(result);
        }
    }
}
