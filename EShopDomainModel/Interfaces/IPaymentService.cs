using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Interfaces
{
    public interface IPaymentService
    {
        bool Pay(decimal price, string card);
    }
}
