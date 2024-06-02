using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        public bool AddCart(int quantity);
        //public void GetFromCart(int userId);
        //public void RemoveCart(int bookId);
    }
}
