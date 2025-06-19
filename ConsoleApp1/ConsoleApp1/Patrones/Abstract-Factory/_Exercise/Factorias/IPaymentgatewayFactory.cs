using ConsoleApp1.Patrones.Abstract_Factory._Exercise.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory._Exercise.Factorias
{
    public interface IPaymentgatewayFactory
    {
       IPaymentGateWay CreatePayment();
       ITransactionLogger CreateTransactionLogger();
    }
}
