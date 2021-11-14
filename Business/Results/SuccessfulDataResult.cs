using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class SuccessfulDataResult<T> : DataResult<T>
    {
        public SuccessfulDataResult(T data, string message) : base(data, true, message) { }
        public SuccessfulDataResult(T data) : base(data, true) { }
    }
}
