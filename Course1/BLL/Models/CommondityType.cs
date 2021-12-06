using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public partial class CommondityType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public CommondityType() { }
        public CommondityType(COMMONDITY_TYPE_REF ctr)
        {
            Id = ctr.ID;
            Type = ctr.TYPE;
        }
    }
}
