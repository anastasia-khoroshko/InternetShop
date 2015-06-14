using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class Category:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
