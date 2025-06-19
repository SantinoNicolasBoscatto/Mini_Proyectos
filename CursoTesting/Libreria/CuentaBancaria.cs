using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class CuentaBancaria
    {
        private readonly ILoggerGeneral _logger;
        public int Balance { get; set; }
        public CuentaBancaria(ILoggerGeneral logger)
        {
            Balance = 0;
            this._logger = logger;
        }

        public bool Deposito(int monto)
        {
            Balance += monto;
            _logger.Message("Se esta depositando: $" + monto);
            _logger.Message("Otro Texto");
            _logger.Message("Visita mi pagina");
            _logger.PrioridadLogger = 33;
            return true;
        }
        public bool Retiro(int monto)
        {
            if(monto>Balance) return _logger.LogBalancePostRetiro(Balance - monto);
            _logger.LogDatabase("Monto de retiro: "+monto.ToString());
            Balance -= monto;
            return _logger.LogBalancePostRetiro(Balance);
        }
        public int GetBalance() => Balance;
    }
}
