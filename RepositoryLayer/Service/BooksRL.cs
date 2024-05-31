using Microsoft.Data.SqlClient;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RepositoryLayer.Service
{
    public class BooksRL : IBooksRL
    {
        private readonly BookStoreDbContext _context;
        public BooksRL(BookStoreDbContext context)
        {
            _context = context;
        }

        public Books AddBooks(AddBookModel model, int userId)
        {            
            Books books = new Books();
            
                books.BookName = model.BookName;
                books.AuthorName = model.AuthorName;
                books.Price = model.Price;
                books.DiscountPrice = model.DiscountPrice;
                books.BookDescription = model.BookDescription;
                books.BookImage = model.BookImage;
                books.UserId = userId;

                _context.Books.Add(books);
                _context.SaveChanges();
                      
            return books;
        }

        public Books GetAllBooks(int userId)
        {
            List<Books> books = _context.Books.ToList<Books>();
            var data = _context.Books.FirstOrDefault(f=> f.UserId == userId);

            Books book = new Books();
            foreach (var item in books)
            {
                book.BookId = data.BookId;
                book.BookName = data.BookName;
                book.AuthorName = data.AuthorName;  
                book.Price = data.Price;
                book.DiscountPrice = data.DiscountPrice;
                book.BookDescription = data.BookDescription;
                book.BookImage = data.BookImage;                
            }
            return book;
        }
    }
}
