using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Proxy.Subject
{
    public interface IBankAccount
    {
        void Deposit(int amount);
        bool Withdraw(int amount);
        int GetBalance();
    }
}
