using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    class ValidationException:Exception
    {
        public ValidationException(string message, Exception innerException)
           : base(message, innerException)
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
