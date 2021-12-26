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
    public partial class Status
    {
        public int Id { get; set; }

        public string StatusSup { get; set; }

        public Status() { }
        public Status(SUPPLY_STATUS_REF s)
        {
            Id = s.ID;
            StatusSup = s.STATUS;
        }
    }
}
