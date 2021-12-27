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
    public partial class ProviderSupplyStock
    {
        public int Id { get; set; }

        public int CommondityId { get; set; }

        public int ProviderId { get; set; }

        public decimal Cost { get; set; }
        public bool vigoda { get; set; }

        public ProviderSupplyStock() { }
        public ProviderSupplyStock(PROVIDER_SUPPLY_STOCK p)
        {
            Id = p.ID;
            CommondityId = p.COMMONDITY_ID;
            ProviderId = p.PROVIDER_ID;
            Cost = p.COST;
            vigoda = p.VIGODA;
        }
    }
}
