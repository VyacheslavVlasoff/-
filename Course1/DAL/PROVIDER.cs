namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROVIDER")]
    public partial class PROVIDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVIDER()
        {
            PROVIDER_SUPPLY_STOCK = new HashSet<PROVIDER_SUPPLY_STOCK>();
            SUPPLY = new HashSet<SUPPLY>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FAMILY_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string INITIALS { get; set; }

        [Required]
        [StringLength(50)]
        public string COMPANY_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVIDER_SUPPLY_STOCK> PROVIDER_SUPPLY_STOCK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLY> SUPPLY { get; set; }
    }
}
