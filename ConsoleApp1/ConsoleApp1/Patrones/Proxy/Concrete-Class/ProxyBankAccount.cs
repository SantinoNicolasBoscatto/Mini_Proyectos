using ConsoleApp1.Patrones.Proxy.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Proxy.Concrete_Class
{
    public class ProxyBankAccount : IBankAccount
    {
        private BankAccount bankAccount;
        public ProxyBankAccount(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public void Deposit(int amount)
        {
            bankAccount.Deposit(amount);
        }
        public int GetBalance()
        {
           return bankAccount.GetBalance();
        }

        public bool Withdraw(int amount)
        {
           if(amount > 15000)
           {
               Console.WriteLine("Esta operacion necesita de aprobacion");
               return false;
           }
           else
           {
               return bankAccount.Withdraw(amount);
           }
        }
    }
}
