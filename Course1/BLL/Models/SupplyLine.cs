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
        public int Id { get; set; }

        public int SupplyId { get; set; }

        public int CommondityId { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public SupplyLine() { }
        public SupplyLine(SUPPLY_LINE i)
        {
            Id = i.ID;
            SupplyId = i.SUPPLY_ID;
            CommondityId = i.COMMONDITY_ID;
            Quantity = i.QUANTITY;
            Cost = i.COST;
        }
        public SupplyLine(List<SUPPLY_LINE> s)
        {
            s.Select(i => new SupplyLine {
                Id = i.ID,
            SupplyId = i.SUPPLY_ID,
            CommondityId = i.COMMONDITY_ID,
            Quantity = i.QUANTITY,
            Cost = i.COST
        }).ToList();
        }
    }
}
