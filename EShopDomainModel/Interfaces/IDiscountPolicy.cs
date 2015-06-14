using EShopDomainModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Interfaces
{
    public interface IDiscountPolicy
    {
        decimal CalculatePrice(List<Item> items);
    }
}
