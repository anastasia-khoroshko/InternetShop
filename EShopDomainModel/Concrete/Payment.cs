using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class Payment:IPayment
    {
        public void Pay(IPaymentService payment,IRepository<Order> orderRepository,Guid orderId,decimal price,string card)
        {
            if (price == 0 || null == card || card == string.Empty)
                throw new NullReferenceException();
            try
            {
                var order = orderRepository.GetByPredicate(orderId);
                if (order != null)
                {
                    if (payment.Pay(price, card))
                    {
                        order.State = new State { StateOrder = StateOrder.Ordered };
                        orderRepository.Update(order);
                    }
                    else new Exception("Invalid transaction");
                }
                else
                    throw new Exception("This order doesn't exist");
            }
            catch(Exception ex)
            {
                throw new Exception("Invalid operation", ex);
            }
        }
    }
}
