namespace WydatkiDomoweWeb.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expenses.RecipientView")]
    public partial class RecipientView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string Account { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string Street { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string BuildingNR { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(6)]
        public string PostCode { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(15)]
        public string City { get; set; }
    }
}
