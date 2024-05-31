using ModelLayer.Model;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBooksRL
    {
        public Books AddBooks(AddBookModel model, int userId);
        public Books GetAllBooks(int userId);

        public Books GetBoookById(int id);
    }
}
