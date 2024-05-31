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

        public Books GetAllBooks(int userId);
    }
}
