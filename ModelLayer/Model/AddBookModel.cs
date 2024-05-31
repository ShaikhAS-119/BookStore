using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ModelLayer.Model
{
    public class AddBookModel
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int Price { get; set; }
        public int DiscountPrice  { get; set; }
        public string BookDescription { get; set; } = string.Empty;
        public string BookImage { get; set; }

    }
}
