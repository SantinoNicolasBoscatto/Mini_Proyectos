using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Error de validacion") {}
        public ValidationException(string error) : base(error) { }
    }
}
