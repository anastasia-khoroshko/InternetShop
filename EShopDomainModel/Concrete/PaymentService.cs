using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class PaymentService:IPaymentService
    {
        public bool Pay(decimal price, string card)
        {
            throw new NotImplementedException();
        }
    }
}
