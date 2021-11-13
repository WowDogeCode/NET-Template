using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class Result
    {
        public Result(bool successful) => IsSuccessful = successful;
        public Result(bool successful, string message) : this(successful) => Message = message;
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
