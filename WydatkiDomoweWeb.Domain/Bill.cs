namespace WydatkiDomoweWeb.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expenses.Bills")]
    public partial class Bill
    {
        [Key]
        public int BillsID { get; set; }

        public int BillNameID { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        public int RecipientID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequiredDate { get; set; }

        public virtual BillName BillName { get; set; }

        public virtual Recipient Recipient { get; set; }
    }
}
