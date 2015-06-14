using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class Discount:IEntity
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
