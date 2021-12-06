namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WAREHOUSE")]
    public partial class WAREHOUSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WAREHOUSE()
        {
            SUPPLY = new HashSet<SUPPLY>();
            WAREHOUSE_LINE = new HashSet<WAREHOUSE_LINE>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLY> SUPPLY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WAREHOUSE_LINE> WAREHOUSE_LINE { get; set; }
    }
}
