using ConsoleApp1.Patrones.Iterator._Exercises.Concrete_Iterator;
using ConsoleApp1.Patrones.Iterator._Exercises.IColection;
using ConsoleApp1.Patrones.Iterator.IIterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Iterator._Exercises.Concrete_Invoker
{
    public class FacebookUsersDB : IColection<FacebookUser>
    {
        private List<FacebookUser> _users;
        public FacebookUsersDB()
        {
            _users = new List<FacebookUser>
            {
                new FacebookUser(1, "Pepe"),
                new FacebookUser(2, "Jose"),
                new FacebookUser(3, "Juan")
            };
        }

        public IIterator<FacebookUser> CreateIterator()
        {
            return new UserIterator(_users);
        }
    }
}
