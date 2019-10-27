using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CustomException : Exception
    {
        public string ReturnMessage { get; set; }
        public override string Message => ReturnMessage;
        public CustomException()
        {

        }


        public string Code { get; }


        public CustomException(string code)
        {
            Code = code;
        }
        public CustomException(string code, string message)
        {
            Code = code;
            ReturnMessage = message;
        }

        public CustomException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }
        public CustomException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
            ReturnMessage = String.Format(message, args);
            Code = code;
        }

        public CustomException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public CustomException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

    }
}
