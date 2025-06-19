using ConsoleApp1.Patrones.Iterator._Exercises.IColection;
using ConsoleApp1.Patrones.Iterator.IIterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Iterator._Exercises.Concrete_Iterator
{
    public class UserIterator : IIterator<FacebookUser>
    {
        private List<FacebookUser> _users;
        private int position = 0;
        public UserIterator(List<FacebookUser> users)
        {
            _users = users;
        }

        public bool HasNext()
        {
            return position < _users.Count;
        }
        public FacebookUser Next()
        {
            var user = _users[position];
            position++;
            return user;
        }
    }
}
