using ConsoleApp1.Patrones.Abstract_Factory._Exercise.Abstracciones;
using ConsoleApp1.Patrones.Abstract_Factory._Exercise.Factorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Abstract_Factory._Exercise
{
    // Creo una clase service que reciba la factoria base por constructor, asi luego puedo pasarle cualquier clase que 
    // implemente esa factory
    public class PaymentService
    {
        private readonly IPaymentGateWay _gateWay;
        private readonly ITransactionLogger _transactionLogger;

        public PaymentService(IPaymentgatewayFactory baseFactory)
        {
            _gateWay = baseFactory.CreatePayment();
            _transactionLogger = baseFactory.CreateTransactionLogger();
        }


        public void ProcessPayment()
        {
            _gateWay.PaymentGateway();
            _transactionLogger.TransactionLogger();
        }
    }
}
