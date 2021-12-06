using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public partial class SupplyLine
    {
        public int SupplyId { get; set; }

        public int CommondityId { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public SupplyLine() { }
        public SupplyLine(SupplyLine s)
        {
            SupplyId = s.SupplyId;
            CommondityId = s.CommondityId;
            Quantity = s.Quantity;
            Cost = s.Cost;
        }
    }
}
