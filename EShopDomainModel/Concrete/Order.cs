using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class Order:IEntity
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public State State{get;set;}
        public ICollection<OrderDetail> Detailes {get;set;}
    }
}
