using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.Result
{
    public enum ResultStatus
    {
        Success,
        NotFound,
        ValidationError,
        Conflict,
        Unauthorized,
        Forbidden,
        Error 
    }
}
