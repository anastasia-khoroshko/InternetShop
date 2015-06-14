using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class DefaultDiscountPolicy:IDiscountPolicy
    {
        private IRepository<Discount> _discountRepository;

        public DefaultDiscountPolicy(IRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public decimal CalculatePrice(List<Item> items)
        {
            double total=0;
            foreach(Item elem in items)
            {
                int valDiscount=_discountRepository.GetByPredicate(elem.DiscountId).Value;
                total += elem.Price * elem.Amount * valDiscount / 100;
            }
            return (decimal)total;
        }
    }
}
