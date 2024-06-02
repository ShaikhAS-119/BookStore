using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore_App.Repository
{
    public partial class Users
    {
        public Users()
        {
            Books = new HashSet<Books>();
            Cart = new HashSet<Cart>();
        }

        [Key]
        public int UserId { get; set; }
        [StringLength(200)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [StringLength(200)]
        public string Role { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Books> Books { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
