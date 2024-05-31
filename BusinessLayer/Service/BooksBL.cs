
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BooksBL : IBooksBL
    {
        private readonly IBooksRL _IbooksRL;
        public BooksBL(IBooksRL IbooksRL)
        {
            _IbooksRL = IbooksRL;   
        }
        public Books AddBooks(AddBookModel model, int userId)
        {
            return _IbooksRL.AddBooks(model, userId);
        }

        public Books GetAllBooks(int userId)
        {
            return _IbooksRL.GetAllBooks(userId);
        }

        public Books GetBoookById(int id)
        {
           return _IbooksRL.GetBoookById(id);
        }
    }
}
