using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL _cartRL;
        public CartBL(ICartRL cartRL)
        {
            _cartRL = cartRL;
        }
        public bool AddCart(int quantity)
        {
           return _cartRL.AddCart(quantity);
        }

        public void GetFromCart(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCart(int bookId)
        {
           // _cartRL.RemoveCart(bookId);
        }
    }
}
