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
using static System.Reflection.Metadata.BlobBuilder;

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

        public List<Books> GetAllBooks(int userId)
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
            return books;
        }

        public Books GetBoookById(int id)
        {
            var row = _context.Books.FirstOrDefault(f=> f.BookId == id);

            Books book = new Books();
            if (row != null)
            {                               
                book.BookId = row.BookId;
                book.BookName = row.BookName;
                book.AuthorName = row.AuthorName;
                book.Price = row.Price;
                book.DiscountPrice = row.DiscountPrice;
                book.BookDescription = row.BookDescription;
                    book.BookImage = row.BookImage;                               
            }

            return book;

        }

        public Books EditBookById(int id, EditBookModel model)
        {
            var row = _context.Books.FirstOrDefault(f=>f.BookId == id);

            Books book = null;
             book = new Books();

            if (row != null)
            {                
                row.BookName = model.BookName;
                row.AuthorName = model.AuthorName;
                row.Price = model.Price;
                row.DiscountPrice = model.DiscountPrice;
                row.BookDescription = model.BookDescription;
                row.BookImage = model.BookImage;

                
                _context.SaveChanges();
            }
            return book;
        }
    }
}
