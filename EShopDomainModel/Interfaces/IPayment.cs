using EShopDomainModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Interfaces
{
    public interface IPayment
    {
        void Pay(IPaymentService payment, IRepository<Order> orderRepository,Guid orderId, decimal price, string card);
    }
}
