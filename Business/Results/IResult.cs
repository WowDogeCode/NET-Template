using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public interface IResult {
        bool Successful { get; set; }
        string Message { get; set; }
    }
}
