using ConsoleApp1.Patrones.Abstract_Factory._Exercise.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory._Exercise.Concrete_Class
{
    public class PaypalPaymentGateWay : IPaymentGateWay
    {
        public void PaymentGateway()
        {
            Console.WriteLine("Pago paypal");
        }       
    }

    public class PaypalTransactionLogger : ITransactionLogger
    {
        public void TransactionLogger()
        {
            Console.WriteLine("Logueo paypal");
        }
    }
}
