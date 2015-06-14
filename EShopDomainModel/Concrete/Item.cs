using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class Item:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Guid DiscountId { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
