using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Implementation
{
    public class ValidationService : Exception
    {
        public string Property { get; protected set; }
        public ValidationService(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
