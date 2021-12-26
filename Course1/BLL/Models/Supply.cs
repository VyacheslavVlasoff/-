using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public partial class Supply
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public int WarehouseId { get; set; }

        public int ApplicantId { get; set; }

        public int Status { get; set; }

        public decimal Cost { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public Supply() { }
        public Supply(SUPPLY s)
        {
            Id = s.ID;
            ProviderId = s.PROVIDER_ID;
            WarehouseId = s.WAREHOUSE_ID;
            ApplicantId = s.APPLICANT_ID;
            Status = s.STATUS_ID;
            Cost = s.COST;
            ApplicationDate = s.APPLICATION_DATE;
            DeliveryDate = s.DELIVERY_DATE;
        }
    }
}
