using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [TestFixture] // Es el TestClass pero de NUnit
    public class OperacionNUnitTest
    {
        private Operacion _operacion = null!;
        [SetUp]
        public void Setup()
        {
            _operacion = new Operacion();
        }

        [Test] // Es el TestMethod Pero de NUnit
        public void Sumar_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            var op = new Operacion();
            int num1 = 4;
            int num2 = 6;

            // Act
            var result = op.Sumar(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        public void IsPar_InputNumeroPar_ReturnTrue(int num1)
        {
            var op = new Operacion();

            var result = op.IsPar(num1);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(6, ExpectedResult = true)]
        public bool IsPar_InputNumeroPar_ReturnBool(int num1)
        {
            var op = new Operacion();
            return op.IsPar(num1);
        }


        [Test]
        [TestCase(2.5, 1.75)]
        [TestCase(2.5, 1.85)]
        public void SumarDecimales_InputDosNumeros_ReturnValorCorrecto(double num1, double num2)
        {
            var op = new Operacion();
            var result = op.SumarDecimal(num1, num2);
            // WithIn define el rango de tolenrancia, en este caso 0.1 positivo y negativo
            Assert.That(result, Is.EqualTo(4.25).Within(0.1)); 
        }


        [Test]
        public void GetListaNumerosImpares_InputMinValueMaxValue_ReturnListaImpar()
        {
            List<int> numerosEsperados = new List<int> { 1, 3, 5, 7, 9 };
            _operacion.GetListaNumerosImpares(1, 10);
            // EquivalentTo me permitira comparar listas mas facilmente.
            Assert.That(_operacion.NumerosImpares, Is.EquivalentTo(numerosEsperados));

            // Evaluamos que la lista contenga X valor
            Assert.That(_operacion.NumerosImpares, Does.Contain(1));

            // Evaluamos que la lista no contenga X valor, ambas funcionan igual
            Assert.That(_operacion.NumerosImpares, Does.Not.Contain(2));
            Assert.That(_operacion.NumerosImpares, Has.No.Member(33));

            // Evaluaremos que la lista no este vacia
            Assert.That(_operacion.NumerosImpares, Is.Not.Empty);

            // Evaluaremos la cantidad de elementos
            Assert.That(_operacion.NumerosImpares.Count, Is.EqualTo(5));

            // Evaluaremos si estan ordenados ascendentemente
            Assert.That(_operacion.NumerosImpares, Is.Ordered);

            // Evaluo no tener valores duplicados
            Assert.That(_operacion.NumerosImpares, Is.Unique);
        }
    }
}
