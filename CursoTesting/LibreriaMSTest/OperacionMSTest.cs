using Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMSTest
{
    [TestClass] // Nomenclatura: NombreClase_Framework_Test
    public class OperacionMSTest
    {
        [TestMethod] // Nomenclatura: MetodoOriginal_Parametros_OperacionAValidar
        public void Sumar_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange: Inicializar variables y/o Objetos, es decir setearle valores.
            var op = new Operacion();
            int num1 = 4;
            int num2 = 6;

            // Act: Ejecucion del metodo a evaluar
            var result = op.Sumar(num1, num2);

            // Assert: Verificar el resultado.
            Assert.AreEqual(10, result);
        }
    }
}
