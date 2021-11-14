using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class SuccessfulResult : Result
    {
        public SuccessfulResult() : base(true) { }
        public SuccessfulResult(string message) : base(true, message) { }
    }
}
