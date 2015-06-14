using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class OrderDetail:IEntity
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int Count { get; set; }
        public Guid OrderId { get; set; }
    }
}
