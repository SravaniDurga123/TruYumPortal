using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruYumPortal.Models
{
    public class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string FreeDelivery { get; set; }
        public string Active { get; set; }

    }
}
