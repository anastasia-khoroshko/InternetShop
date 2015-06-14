using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class FormedOrderException:Exception
    {
        public FormedOrderException(){}

        public FormedOrderException(string message) : base(message) { }

        public FormedOrderException(string message, Exception inner) : base(message, inner) { }
    }
}
