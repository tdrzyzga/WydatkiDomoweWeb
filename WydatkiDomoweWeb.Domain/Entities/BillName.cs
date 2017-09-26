namespace WydatkiDomoweWeb.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expenses.BillName")]
    public partial class BillName
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillName()
        {
            Bills = new HashSet<Bill>();
        }

        public int BillNameID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime FirstPaymentDate { get; set; }

        public int PaymentsFrequency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
