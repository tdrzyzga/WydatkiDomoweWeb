namespace WydatkiDomoweWeb.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expenses.MainView")]
    public partial class MainView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string Bill { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(26)]
        public string Recipient { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal Amount { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime RequiredDate { get; set; }
    }
}
