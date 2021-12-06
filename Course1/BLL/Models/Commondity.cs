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
    public partial class Commondity
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Тип продукции")]
        public int CommondityType { get; set; }

        [DisplayName("Размер")]
        public int? Size { get; set; }      

        public Commondity() { }
        public Commondity(COMMONDITY c)
        {
            Id = c.ID;
            Name = c.NAME;
            CommondityType = c.COMMONDITY_TYPE;
            Size = c.SIZE;
        }
    }
}
