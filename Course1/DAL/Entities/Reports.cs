using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CreateSupplyData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CommonId { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public int? Size { get; set; }
        public string Provider { get; set; }
        public decimal Cost { get; set; }
        public bool check { get; set; }
        public int Quantity { get; set; }

        public int ProviderId { get; set; }
    }

    public class CreateWarehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
    }
}
