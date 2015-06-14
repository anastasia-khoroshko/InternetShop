using EShopDomainModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Interfaces
{
    public interface IShoppingCart
    {
        Order Order { get; }
        int Count { get; }
        List<Item> AllItems { get; }
        void AddInCart(Item entity);
        void DeleteFromCart(Guid key);
        void UpdateCart(Item entity);
        void CancelOrder();
        void SaveCart(IRepository<Order> orderRepository, IRepository<OrderDetail> detailRepository);
        decimal CalculateTotalPrice(List<Item> items);
        void MakePayment(IPaymentService payment,string card);
    }
}
