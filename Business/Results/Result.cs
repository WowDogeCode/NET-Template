using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class Result : IResult
    {
        public Result(bool successful) => Successful = successful;
        public Result(bool successful, string message) : this(successful) => Message = message;
        public bool Successful { get; set; }
        public string Message { get; set; }
    }
}
