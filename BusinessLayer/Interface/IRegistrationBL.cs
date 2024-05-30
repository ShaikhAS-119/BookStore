using ModelLayer.Model;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IRegistrationBL
    {
        public Users Register(RegistrationModel model, String role);
        
        public string Login(LoginModel model);

    }
}
