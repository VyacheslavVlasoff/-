namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUPPLY_LINE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SUPPLY_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COMMONDITY_ID { get; set; }

        public int QUANTITY { get; set; }

        public decimal COST { get; set; }

        public virtual COMMONDITY COMMONDITY { get; set; }

        public virtual SUPPLY SUPPLY { get; set; }
    }
}
