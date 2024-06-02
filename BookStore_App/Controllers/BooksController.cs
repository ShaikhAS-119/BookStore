using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Add New Books
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get All Books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("get")]
        public List<Books> GetBooks()
        {
            var _userId = User.FindFirstValue("userId");
            var userId = Convert.ToInt32(_userId);

            List<Books> books =_IbooksBL.GetAllBooks(userId);
            var response = new ResponseModel<List<Books>>();

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

            return books;
        }

        /// <summary>
        /// Get Book By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]         
        //check user id
        public ResponseModel<Books> GetById(int id)
        {
            var data = _IbooksBL.GetBoookById(id);
            var response = new ResponseModel<Books>();

            if( data != null )
            {
                response.success=true;
                response.message = "get successfull";
                response.data = data;                
            }
            else
            {
                response.success=false;
                response.message = "failed to get";
            }

            return response;
        }

        /// <summary>
        /// Edit Book Details
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{bookId}")]
        //check user id
        public ResponseModel<Books> EditBook(int bookId, EditBookModel model)
        {
           var data = _IbooksBL.EditBookById(bookId, model);
            var response = new ResponseModel<Books>();

            if(data!=null)
            {
                response.success = true;
                response.message = "Edited Successfully";
                response.data = data;
            }
            else
            {
                response.success=false;
                response.message = "Failed to update";
            }

            return response ;
        }

        /// <summary>
        /// Delete Book By ID
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            var data = _IbooksBL.DeleteBookById(bookId);
            var response = new ResponseModel<bool>();

            if(data)
            {
                response.success=true;
                response.message = "Deleted Successfully";
                response.data = data;
            }
            else
            {
                response.success=false;
                response.message = "Failed to delete";
            }
            return Ok(response);
        }
    }
}
