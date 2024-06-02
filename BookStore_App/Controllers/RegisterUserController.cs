using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.Repository;
using System.Linq;

namespace BookStore_App.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegistrationBL _registrationBL;
        private readonly BookStoreDbContext _dbContext;
        public RegisterUserController(IRegistrationBL registrationBL, BookStoreDbContext dbContext)
        {
            _registrationBL = registrationBL;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterUser(RegistrationModel model)
        {
            return Ok(Register(model, "User"));
        }

        /// <summary>
        /// Add Admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("admin")]
        public IActionResult RegisterAdmin(RegistrationModel model)
        {
            return Ok(Register(model, "Admin"));
        }       
        
        private ResponseModel<RegistrationModel> Register(RegistrationModel model, string role)
        {
            var user = _dbContext.Users.FirstOrDefault(c => c.Email == model.Email);
            var response = new ResponseModel<RegistrationModel>();

            if (user != null)
            {
                response.message = "Already Exist";
                return response;
            }
            else
            {
                var data = _registrationBL.Register(model, role);
                if (data != null)
                {
                    response.message = "Successfully registered";
                    response.success = true;
                    response.data = model;                    
                }
                else
                {
                    response.success = false;
                    response.message = "Failed to register";

                    return response;
                }
            }
            return response;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            var data = _registrationBL.Login(model);

            var response = new ResponseModel<string>();

            if (data != null)
            {
                response.success = true;
                response.message = "Successfully logged in";
                response.data = data;

                return Ok(response);
            }
            else
            {
                response.success = false;
                response.message = "failed to login";
                return Unauthorized(response);
            }

            

        }
    }
}
