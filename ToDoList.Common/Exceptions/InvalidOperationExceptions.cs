using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common.Exceptions
{
    public class InvalidOperationExceptions: ToDoListException
    {
        public InvalidOperationExceptions() : base("Service Validation Exception")
        {
        }

        public InvalidOperationExceptions(string message) : base(message)
        {
        }

        public InvalidOperationExceptions(int code, string message) : base(code, message)
        {
        }

        public InvalidOperationExceptions(string message, Exception ex) : base(message, ex)
        {
        }

        public InvalidOperationExceptions(int code, string message, Exception ex) : base(code, message, ex)
        {
        }

    }
}
