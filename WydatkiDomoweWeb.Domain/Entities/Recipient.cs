namespace WydatkiDomoweWeb.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expenses.Recipient")]
    public partial class Recipient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipient()
        {
            Bills = new HashSet<Bill>();
        }

        public int RecipientID { get; set; }

        [Required]
        [StringLength(26)]
        public string Name { get; set; }

        public int PostCodeID { get; set; }

        public int CityID { get; set; }

        public int StreetID { get; set; }

        [Required]
        [StringLength(5)]
        public string BuildingNR { get; set; }

        [Required]
        [StringLength(26)]
        public string Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual City City { get; set; }

        public virtual PostCode PostCode { get; set; }

        public virtual Street Street { get; set; }
    }
}
