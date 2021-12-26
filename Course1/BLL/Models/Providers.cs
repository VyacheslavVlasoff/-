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
    public partial class Providers
    {

        public int Id { get; set; }

        public string FamilyName { get; set; }

        public string Initials { get; set; }

        public string CompanyName { get; set; }

        public Providers() { }
        public Providers(PROVIDER p)
        {
            Id = p.ID;
            FamilyName = p.FAMILY_NAME;
            Initials = p.INITIALS;
            CompanyName = p.COMPANY_NAME;
        }

    }
}
