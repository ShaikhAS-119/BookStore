using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore_App.Repository
{
    public partial class Books
    {
        public Books()
        {
            Cart = new HashSet<Cart>();
        }

        [Key]
        public int BookId { get; set; }
        [StringLength(200)]
        public string BookName { get; set; }
        [StringLength(200)]
        public string AuthorName { get; set; }
        public int Price { get; set; }
        public int? DiscountPrice { get; set; }
        [StringLength(500)]
        public string BookDescription { get; set; }
        [StringLength(700)]
        public string BookImage { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Books))]
        public virtual Users User { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
