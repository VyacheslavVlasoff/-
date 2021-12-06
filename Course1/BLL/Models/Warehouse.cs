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
    public partial class Warehouse
    {
        public int Id { get; set; }

        public string Addres { get; set; }

        public Warehouse() { }
        public Warehouse(WAREHOUSE w)
        {
            Id = w.ID;
            Addres = w.ADDRESS;
        }
    }
}
