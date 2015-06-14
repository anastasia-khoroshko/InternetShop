using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public enum StateOrder
    {
        InProgress, Ordered, Delivered
    }
    public class State
    {
        public StateOrder StateOrder { get; set; }
    }
}
