using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class ShoppingCart : IShoppingCart
    {
        private IRepository<Item> _itemsRepository;
        private IDiscountPolicy _discountPolicy;
        private List<Item> items;
        private Order order;

        public Order Order
        {
            get
            {
                return order;
            }
        }
        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public List<Item> AllItems
        {
            get
            {
                return items;
            }
        }
        public ShoppingCart(IRepository<Item> itemsRepository, IDiscountPolicy discountPolicy)
        {
            _itemsRepository = itemsRepository;
            _discountPolicy = discountPolicy;
            items = new List<Item>();
            order = new Order() { Id = Guid.NewGuid() };
        }

        public void AddInCart(Item entity)
        {
            if (entity != null)
            {
                var existItem = items.Where(i => i.Id == entity.Id).FirstOrDefault();
                var elem = _itemsRepository.GetByPredicate(entity.Id);
                var count = elem.Amount;
                if (existItem != null)
                {
                    entity.Amount += existItem.Amount;
                    if (entity.Amount <= count)
                        UpdateCart(entity);
                    else throw new FormedOrderException("Haven't got enough item");
                }
                else if (entity.Amount <= count)
                    items.Add(entity);
                else throw new FormedOrderException("Haven't got enough item");
            }
            else throw new FormedOrderException("Null item");
        }
        public void DeleteFromCart(Guid key)
        {
            Item item = items.Where(i => i.Id == key).FirstOrDefault();
            if (item != null)
                items.Remove(item);
            else throw new FormedOrderException("No this element in shopping cart");
        }
        public void UpdateCart(Item entity)
        {
            if (entity != null)
            {
                Item oldValue = items.Where(i => i.Id == entity.Id).FirstOrDefault();
                int index = items.IndexOf(oldValue);
                if (index != -1)
                {
                    items[index] = entity;
                }
                else throw new FormedOrderException("This item doesn't have shopping cart");
            }
            else throw new FormedOrderException("Invalid parameters");
        }

        public void CancelOrder()
        {
            items.Clear();
        }
        public void SaveCart(IRepository<Order> orderRepository, IRepository<OrderDetail> detailRepository)
        {
            order.TotalPrice = CalculateTotalPrice(items);
            order.State = new State() { StateOrder = StateOrder.InProgress };
            orderRepository.Create(order);

            foreach (Item elem in items)
            {
                detailRepository.Create(new OrderDetail()
                {
                    Id = Guid.NewGuid(),
                    ItemId = elem.Id,
                    Count = elem.Amount,
                    OrderId = order.Id
                });
                elem.Amount = _itemsRepository.GetByPredicate(elem.Id).Amount - elem.Amount;
                _itemsRepository.Update(elem);
            }
        }
                

        public decimal CalculateTotalPrice(List<Item> items)
        {
            return _discountPolicy.CalculatePrice(items);
        }

        public void MakePayment(IPaymentService payment,string card)
        {
            try
            {
                if (order.State.StateOrder == StateOrder.InProgress)
                {
                    if (payment.Pay(order.TotalPrice, card))
                        order.State.StateOrder = StateOrder.Ordered;
                    else throw new Exception("Invalid transaction operation");
                }
                else throw new FormedOrderException("Invalid data of payment");
            }
            catch (Exception ex)
            {
                throw new FormedOrderException("Don't pay order",ex);
            }
        }
    }
}
