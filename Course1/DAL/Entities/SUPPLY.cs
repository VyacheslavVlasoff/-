namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUPPLY")]
    public partial class SUPPLY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUPPLY()
        {
            SUPPLY_LINE = new HashSet<SUPPLY_LINE>();
        }

        public int ID { get; set; }

        public int PROVIDER_ID { get; set; }

        public int WAREHOUSE_ID { get; set; }

        public int APPLICANT_ID { get; set; }

        public int STATUS_ID { get; set; }

        public decimal COST { get; set; }

        public DateTime APPLICATION_DATE { get; set; }

        public DateTime? DELIVERY_DATE { get; set; }

        public virtual PROVIDER PROVIDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLY_LINE> SUPPLY_LINE { get; set; }

        public virtual SUPPLY_STATUS_REF SUPPLY_STATUS_REF { get; set; }

        public virtual USER USER { get; set; }

        public virtual WAREHOUSE WAREHOUSE { get; set; }
    }
}
