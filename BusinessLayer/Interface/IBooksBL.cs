using ModelLayer.Model;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBooksBL
    {
        public Books AddBooks(AddBookModel model, int userId);

        public List<Books> GetAllBooks(int userId);

        public Books GetBoookById(int id);
        public Books EditBookById(int id, EditBookModel model);

        public bool DeleteBookById(int id); 
    }
}
