using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    public partial class WarehouseLine
    {
        public int Id { get; set; }

        public int CommondityId { get; set; }

        public int WarehouseId { get; set; }

        public decimal PerUnitCost { get; set; }

        public int Quantity { get; set; }

        public WarehouseLine() { }
        public WarehouseLine(WAREHOUSE_LINE wl)
        {
            Id = wl.ID;
            CommondityId = wl.COMMONDITY_ID;
            WarehouseId = wl.WAREHOUSE_ID;
            PerUnitCost = wl.PER_UNIT_COST;
            Quantity = wl.QUANTITY;
        }
    }
}
