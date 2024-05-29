using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RepositoryLayer.Repository.Models
{
    public partial class Books
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(200)]
        public string BookName { get; set; }
        [StringLength(200)]
        public string AuthorName { get; set; }
        public int Price { get; set; }
        [Column("Discount_Price")]
        public int? DiscountPrice { get; set; }
        [Column("Book_Description")]
        [StringLength(500)]
        public string BookDescription { get; set; }
        public byte[] BookImage { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Books))]
        public virtual Users User { get; set; }
    }
}
