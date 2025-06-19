using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Libreria
{
    public class OperacionXUnitTest
    {
        [Fact]
        public void Sumar_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            var op = new Operacion();
            int num1 = 4;
            int num2 = 6;

            // Act
            var result = op.Sumar(num1, num2);

            // Assert
            Assert.Equal(10, result);
        }

        [Theory] // En caso de una funcion con parametros y Cases la definimos como Theory
        [InlineData(2)] // Los InlineData() reemplazan a los TestCases
        [InlineData(4)]
        [InlineData(6)]
        public void IsPar_InputNumeroPar_ReturnTrue(int num1)
        {
            var op = new Operacion();

            var result = op.IsPar(num1);

            Assert.True(result);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(6, true)]
        public void IsPar_InputNumeroPar_ReturnBool(int num1, bool expectedResult)
        {
            var op = new Operacion();
            var result = op.IsPar(num1);
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(2.5, 1.75)]
        [InlineData(2.5, 1.85)]
        public void SumarDecimales_InputDosNumeros_ReturnValorCorrecto(double num1, double num2)
        {
            var op = new Operacion();
            var result = op.SumarDecimal(num1, num2);
            // El cero redondeara los decimales del resultado
            Assert.Equal(4.4, result, 0); 
        }


        [Fact]
        public void GetListaNumerosImpares_InputMinValueMaxValue_ReturnListaImpar()
        {
            List<int> numerosEsperados = new List<int> { 1, 3, 5, 7, 9 };
            var operacion = new Operacion();
            operacion.GetListaNumerosImpares(1, 10);
            // Equivalent me permitira comparar listas mas facilmente.
            Assert.Equivalent(numerosEsperados, operacion.NumerosImpares);

            // Evaluamos que la lista contenga X valor
            Assert.Contains(1, operacion.NumerosImpares);

            // Evaluamos que la lista no contenga X valor, ambas funcionan igual
            Assert.DoesNotContain(2, operacion.NumerosImpares);

            // Evaluaremos que la lista no este vacia
            Assert.NotEmpty(operacion.NumerosImpares);

            // Evaluaremos la cantidad de elementos
            Assert.Equal(5, operacion.NumerosImpares.Count);

            // Evaluaremos si estan ordenados ascendentemente
            Assert.Equal(operacion.NumerosImpares.OrderBy(x => x), operacion.NumerosImpares);
        }
    }
}
