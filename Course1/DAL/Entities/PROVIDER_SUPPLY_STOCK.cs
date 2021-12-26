namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROVIDER_SUPPLY_STOCK
    {
        public int ID { get; set; }

        public int COMMONDITY_ID { get; set; }

        public int PROVIDER_ID { get; set; }

        public decimal COST { get; set; }

        public virtual COMMONDITY COMMONDITY { get; set; }

        public virtual PROVIDER PROVIDER { get; set; }
    }
}
