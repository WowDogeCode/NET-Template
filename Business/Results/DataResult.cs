using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool successful, string message) : base(successful, message) => Data = data;
        public DataResult(T data, bool successful) : base(successful) => Data = data;
        public T Data { get; set; }
    }
}
