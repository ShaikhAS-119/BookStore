using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CartRL : ICartRL
    {
        private readonly BookStoreDbContext _context;
        public CartRL(BookStoreDbContext context) 
        {
            _context = context;
        }
        public bool AddCart(int quantity)
        {
            bool check = false;
            //var row = _context.Cart.FirstOrDefault(f=>f.BookId == bookId && f.UserId == userId);
            //if (row == null)
            //{
                Cart cart = new Cart();
                cart.Quantity = quantity;

                _context.Cart.Add(cart);
                _context.SaveChanges();
                check = true;
            //}                                  
            return check;
        }

        public void GetFromCart(int userId)
        {
            throw new NotImplementedException();
        }
        public void RemoveCart(int bookId)
        {
            
        }
    }
}
