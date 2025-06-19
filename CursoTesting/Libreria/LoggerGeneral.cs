using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public interface ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalancePostRetiro(int balancePostRetiro);
        string MessageConReturnString(string message);
        bool MessageConOutParametroReturnBool(string str, out string ouputStr);
        bool MessageConObjetoRefReturnBool(ref Cliente cliente);

    }
    public class LoggerGeneral : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; } = null!;

        public bool LogBalancePostRetiro(int balancePostRetiro)
        {
            if(balancePostRetiro >= 0)
            {
                Console.WriteLine("Retiro Exitoso");
                return true;
            }
            Console.WriteLine("Saldo Insuficiente");
            return false;

        }
        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }
        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public bool MessageConOutParametroReturnBool(string str, out string ouputStr)
        {
            ouputStr = "Hola "+str;
            return true;
        }

        public bool MessageConObjetoRefReturnBool(ref Cliente cliente)
        {
            return true;
        }
    }
}
