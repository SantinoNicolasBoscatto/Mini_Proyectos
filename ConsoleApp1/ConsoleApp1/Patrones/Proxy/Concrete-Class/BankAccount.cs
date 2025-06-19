using ConsoleApp1.Patrones.Proxy.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Proxy.Concrete_Class
{
    public class BankAccount : IBankAccount
    {
        private int _balance;
        public BankAccount(int balance)
        {
            _balance = balance;
        }

        public void Deposit(int amount)
        {
            _balance += amount;
            Console.WriteLine("Se deposito: $" + amount);
        }

        public int GetBalance()
        {
            return _balance;
        }

        public bool Withdraw(int amount)
        {
            if(_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine("Se retiro: $" + amount);
                return true;
            }
            else Console.WriteLine("Saldo Insuficiente");
            return false;
        }
    }
}
