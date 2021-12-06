namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WAREHOUSE_LINE
    {
        public int ID { get; set; }

        public int COMMONDITY_ID { get; set; }

        public int WAREHOUSE_ID { get; set; }

        public decimal PER_UNIT_COST { get; set; }

        public int QUANTITY { get; set; }

        public virtual COMMONDITY COMMONDITY { get; set; }

        public virtual WAREHOUSE WAREHOUSE { get; set; }
    }
}
