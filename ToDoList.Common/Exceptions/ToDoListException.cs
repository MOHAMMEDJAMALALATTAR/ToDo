using System;

namespace ToDoList.Common.Exceptions
{
    public class ToDoListException : Exception
    {
        public int ErrorCode { get; set; }

        public ToDoListException() : base("Tazeez Exception")
        {
        }

        public ToDoListException(string message) : base(message)
        {
        }

        public ToDoListException(int statusCode, string message) : base(message)
        {
            ErrorCode = statusCode;
        }

        public ToDoListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ToDoListException(int statusCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = statusCode;
        }
    }
}
