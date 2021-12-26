namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMMONDITY")]
    public partial class COMMONDITY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMONDITY()
        {
            PROVIDER_SUPPLY_STOCK = new HashSet<PROVIDER_SUPPLY_STOCK>();
            SUPPLY_LINE = new HashSet<SUPPLY_LINE>();
            WAREHOUSE_LINE = new HashSet<WAREHOUSE_LINE>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        public int COMMONDITY_TYPE { get; set; }

        public int? SIZE { get; set; }

        public virtual COMMONDITY_TYPE_REF COMMONDITY_TYPE_REF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVIDER_SUPPLY_STOCK> PROVIDER_SUPPLY_STOCK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLY_LINE> SUPPLY_LINE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WAREHOUSE_LINE> WAREHOUSE_LINE { get; set; }
    }
}
