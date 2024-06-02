using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public bool AddCart(int quantity);
        public void GetFromCart(int userId);
        public void RemoveCart(int bookId);
    }
}
