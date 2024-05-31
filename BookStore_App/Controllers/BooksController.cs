using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;

namespace BookStore_App.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksBL _IbooksBL;
        
        public BooksController(IBooksBL IbooksBL, BookStoreDbContext context)
        {
            _IbooksBL = IbooksBL;
            
            
        }

        [HttpPost]
        [Authorize]        
        public ResponseModel<Books> AddBooks(AddBookModel model)
        {                           
            string _userId = User.FindFirstValue("userId");
            int userId = Convert.ToInt32(_userId);

            var data = _IbooksBL.AddBooks(model, userId);
            var response = new ResponseModel<Books>();

            if(data.BookName != null)
            {
                response.success = true;
                response.message = "Books added successfully";
                response.data = data;
            }
            else
            {
                response.success = false;
                response.message = "Failed to Add successfully";
            }

            return response;
        }

        [HttpGet]              
        public IActionResult GetBooks()
        {
            var _userId = User.FindFirstValue("userId");
            var userId = Convert.ToInt32(_userId);

            Books books =_IbooksBL.GetAllBooks(userId);
            var response = new ResponseModel<Books>();

            if (books != null)
            {
                response.success=true;
                response.message = "getting all books";
                response.data = books;
            }
            else
            {
                response.success=false;
                response.message = "failed to get value";
            }

            return Ok(books);
        }

        [HttpPost]
        [Route("id")]
        public void GetById(int BookId)
        {
            
        }
    }
}
