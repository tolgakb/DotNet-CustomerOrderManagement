using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Common.Exceptions
{
    public class AccessForbiddenException : Exception
    {
        public AccessForbiddenException() : base() { }
    }
}
