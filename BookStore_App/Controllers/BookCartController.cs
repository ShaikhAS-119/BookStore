using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using System;
using System.Runtime.InteropServices;

namespace BookStore_App.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class BookCartController : ControllerBase
    {
        private readonly ICartBL _cartBL;
        public BookCartController(ICartBL cartBL)
        {
            _cartBL = cartBL;
        }

        /// <summary>
        /// Add Book to cart
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        //[HttpPost("{bookId}")] int bookId
        [HttpPost]
        public IActionResult AddCart(int quantity)
        {
            var _user = User.FindFirst("UserId");
            var user =  Convert.ToInt32(_user);

           var data= _cartBL.AddCart(quantity);
            var response = new ResponseModel<bool>();
            if (data)
            {
                response.success = true;
                response.message = "Added to cart";
                response.data = data;

                return Ok(response);
            }
            else
            {
                response.success = false;
                response.message = "Failed to add to cart";

                return BadRequest(response);
            }

        }

        
        [HttpGet]
        public void GetCart()
        {
            
        }

        [HttpDelete("{bookId}")]
        public void DeleteCart(int bookId)
        {
           // _cartBL.RemoveCart(bookId);
        }
    }
}
