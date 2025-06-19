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
    public class CuentaBancariaNUnitTests
    {
        private CuentaBancaria _cuentaBancaria = null!;
        [SetUp]
        public void SetUp() 
        {
        }
        [Test]
        public void Deposito_InputMonto100LoggerFake_ReturnsTrue()
        {
            var mockLogger = new Mock<ILoggerGeneral>();
            var cuentaBancaria = new CuentaBancaria(mockLogger.Object);
            var result = cuentaBancaria.Deposito(100);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Deposito_InputMonto100MOQ_ReturnsTrue()
        {
            // Creo la dependencia falsa mediante el Mock
            var mock = new Mock<ILoggerGeneral>();
            // Uso esa dependencia falsa
            var cuentaBancaria = new CuentaBancaria(mock.Object);
            var result = cuentaBancaria.Deposito(100);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Retiro_Retiro100Balance200_ReturnsTrue()
        {
            var mockLogger = new Mock<ILoggerGeneral>();
            // Configuro la llamada de mi metodo LogDatabase(), pasandole como parametro 
            // Cualquier String, tambien definimos que devuelve un true.
            mockLogger.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            // Con Setup() y Returns() simulamos la ejecucion del metodo de la dependencia, simulamos la
            // ejecucion del metodo del Mock, Colocando arbitrariamente parametros y el resultado que esperamos
            mockLogger.Setup(x => x.LogBalancePostRetiro(It.Is<int>(x => x>0))).Returns(true);
            // Con It.Is<T>() puedo definir algunas condiciones del parametro de entrada, a diferencia de IsAny<T>()


            var cuentaBancaria = new CuentaBancaria(mockLogger.Object);
            cuentaBancaria.Balance = 200;
            var result = cuentaBancaria.Retiro(100);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Retiro_Retiro300Balance200_ReturnsFalse()
        {
            var mockLogger = new Mock<ILoggerGeneral>();
            // IsInRange es otra forma de definir rango de valores.
            mockLogger.Setup(x => x.LogBalancePostRetiro(It.IsInRange<int>(int.MinValue, -1, 
                             Moq.Range.Inclusive))).Returns(false);

            var cuentaBancaria = new CuentaBancaria(mockLogger.Object);
            cuentaBancaria.Balance = 200;
            var result = cuentaBancaria.Retiro(300);
            Assert.That(result, Is.False);
        }

        [Test] // realizo un unit-testing sobre un Mock
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "Hola Soy Texto Prueba";

            // Simulo la funcion, al llamarla desde el Mock se ejecutara lo logica que aca defini
            loggerMock.Setup(x => x.MessageConReturnString(It.IsAny<string>()))
                .Returns<string>(str => str.ToLower());

            // Llamo la funcion, por defecto las funciones de los Mock no tiene logica, pero con Setup yo 
            // Puedo simular una especie de logica
            var result = loggerMock.Object.MessageConReturnString(textoPrueba);
            Assert.That(result, Is.EqualTo(textoPrueba.ToLower()));
        }
        [Test] // realizo un unit-testing sobre un Mock, con parametros Ouput 
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {
            string textoEsperado = "hola";
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(x => x.MessageConOutParametroReturnBool(It.IsAny<string>(), out textoEsperado)).Returns(true);

            var outValue = "";
            var result = loggerMock.Object.MessageConOutParametroReturnBool("Vaxi", out outValue);
            Assert.That(result, Is.True);
        }
        [Test] // realizo un unit-testing sobre un Mock, con parametros Ref
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoRef_ReturnTrue()
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new Cliente();
            Cliente clienteNoUsado = new Cliente();

            // Defino la referencia del objeto de la funcion, si yo le pasara luego otro objeto 
            // daria un error. 
            loggerMock.Setup(x => x.MessageConObjetoRefReturnBool(ref cliente)).Returns(true);
            var result = loggerMock.Object.MessageConObjetoRefReturnBool(ref cliente);
            Assert.That(result, Is.True);
        }

        [Test] // Seteo los valores de las propiedades de un Mock
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            // Setear valores a las propiedades de un Mock
            loggerMock.Setup(x => x.TipoLogger).Returns("Warning");
            loggerMock.Setup(x => x.PrioridadLogger).Returns(3);

            // Este metodo SetupAllProperties() me permite setear manualmente valores, pero borrara los Setups 
            // anteriormente creados, para evitar esto se recomienda colocarla luego de crear el Mock.
            loggerMock.SetupAllProperties();
            loggerMock.Object.PrioridadLogger = 1;
            loggerMock.Object.TipoLogger = "Warning";

            Assert.That(loggerMock.Object.TipoLogger, Is.EqualTo("Warning"));
            Assert.That(loggerMock.Object.PrioridadLogger, Is.EqualTo(1));


            // CALLBACKS
            string text = "Hola";
            loggerMock.Setup(x => x.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                // Callback Capturara el parametro STRING de LogDatabase()
                .Callback((string parameter) => text += parameter);
            loggerMock.Object.LogDatabase(", Soy una callback");
            Assert.That(text, Is.EqualTo("Hola, Soy una callback"));
        }

        [Test] 
        public void CuentaBancariaLoggerGeneral_VerifyMessgge3Times()
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            var cuenta = new CuentaBancaria(loggerMock.Object);
            cuenta.Deposito(100);
            Assert.That(cuenta.GetBalance, Is.EqualTo(100));


            // Verificar cuantas veces el mock llama al metodo Message() del ILoggerGeneral
            loggerMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
            // AtLeastOnce() verifica que se haya ejecutado al menos una vez
            loggerMock.Verify(x => x.Message(It.IsAny<string>()), Times.AtLeastOnce());

            // Con esta propiedad verifico cuentas veces hago el Get sobre una propiedad
            loggerMock.VerifyGet(x => x.PrioridadLogger, Times.Never());
        }
    }
}
