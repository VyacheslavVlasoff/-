namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            SUPPLY = new HashSet<SUPPLY>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LOGIN { get; set; }

        [Required]
        [StringLength(50)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string FIR_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string FAM_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLY> SUPPLY { get; set; }
    }
}
