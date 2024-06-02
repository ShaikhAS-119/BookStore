using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore_App.Repository
{
    public partial class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public int? Quantity { get; set; }
        public int? FinalPrice { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Books.Cart))]
        public virtual Books Book { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Cart))]
        public virtual Users User { get; set; }
    }
}
