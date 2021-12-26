namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMMONDITY_TYPE_REF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMONDITY_TYPE_REF()
        {
            COMMONDITY = new HashSet<COMMONDITY>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMONDITY> COMMONDITY { get; set; }
    }
}
