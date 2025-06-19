using System.ComponentModel.DataAnnotations;
using WebApiActores.Validaciones;

namespace WebAPIAutores.Tests.PruebasUnitarias
{
    [TestClass]
    public class PrimeraLetraMayusculaAttributeTests
    {
        [TestMethod]
        public void PrimeraLetraMinuscula_DevuelveError()
        {
            //Preparacion
            var primeraLetra = new PrimeraLetraMayusculaAttribute();
            var name = "pepe";
            var valContext = new ValidationContext(new {Nombre = name });
            //Ejecucion
            var resultado = primeraLetra.GetValidationResult(name, valContext);

            //Verificacion
            Assert.AreEqual("La primera letra debe ser mayuscula", resultado!.ErrorMessage);
        }

        [TestMethod]
        public void ValorNull_Exitoso()
        {
            //Preparacion
            var primeraLetra = new PrimeraLetraMayusculaAttribute();
            string? name = null;
            var valContext = new ValidationContext(new { Nombre = name });
            //Ejecucion
            var resultado = primeraLetra.GetValidationResult(name, valContext);
            //Verificacion
            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_Exitoso()
        {
            //Preparacion
            var primeraLetra = new PrimeraLetraMayusculaAttribute();
            string? name = "Pepe";
            var valContext = new ValidationContext(new { Nombre = name });
            //Ejecucion
            var resultado = primeraLetra.GetValidationResult(name, valContext);
            //Verificacion
            Assert.IsNull(resultado);
        }
    }
}