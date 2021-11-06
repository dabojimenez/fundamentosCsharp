using System;
using System.Collections.Generic;
using System.Text;

namespace fundamentosCsharp.Errors
{
    public class CervezaNotFoundException : Exception
    {
        public CervezaNotFoundException() : base()
        {

        }

        public CervezaNotFoundException(string message): base(message) { }

        public CervezaNotFoundException(string message, Exception internaException): base(message, internaException) { }
    }
}
