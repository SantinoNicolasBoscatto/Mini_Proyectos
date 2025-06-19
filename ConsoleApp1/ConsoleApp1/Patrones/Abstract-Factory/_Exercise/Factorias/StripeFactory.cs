using ConsoleApp1.Patrones.Abstract_Factory._Exercise.Abstracciones;
using ConsoleApp1.Patrones.Abstract_Factory._Exercise.Concrete_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory._Exercise.Factorias
{
    public class StripeFactory : IPaymentgatewayFactory
    {
        public IPaymentGateWay CreatePayment()
        {
            return new StripePaymentGateway();
        }

        public ITransactionLogger CreateTransactionLogger()
        {
            return new StripeTransactionLogger();
        }
    }
}
