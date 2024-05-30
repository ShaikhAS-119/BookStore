using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiddlewareServices;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RepositoryLayer.Service
{
    public class RegistrationRL : IRegistrationRL
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IConfiguration _Config;
        public RegistrationRL(BookStoreDbContext dbContext, IConfiguration Config)
        {
            _dbContext = dbContext; 
            _Config = Config;   
        }       

        public Users Register(RegistrationModel model, String role)
        {
            Users user = new Users();
            try
            {
                var hashPass = GenerateHash.GetHash(model.Password);
               
                user.Username = model.Username;
                user.Password = hashPass;
                user.Email = model.Email;
                user.Role = role;

                _dbContext.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //it will return instance of class
            return user;
        }

        public string Login(LoginModel model)
        {

            // FirstOrDefault :LINQ method that returns the first element
            var data = _dbContext.Users.FirstOrDefault(c => c.Email == model.Email);
            var hashpassOfUser = _dbContext.Users
                                    .Where(u => u.Email == model.Email)
                                    .Select(u => u.Password)
                                    .FirstOrDefault();
            //checked pass new and hashpass
            var pass = VerifyPass.GetPass(model.Password, hashpassOfUser);

            if (pass && data != null)
            {
                var key = Environment.GetEnvironmentVariable("jwtKey");
                var issu = Environment.GetEnvironmentVariable("jwtIssuer");
                var aud = Environment.GetEnvironmentVariable("jwtAudience");

                var email = model.Email;
                var role = data.Role;

                var token = new GenerateToken().Generate(key, issu, aud, email, role);
                return token;
            }
            return null;
        }
    }
}
