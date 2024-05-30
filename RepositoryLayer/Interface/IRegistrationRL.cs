using ModelLayer.Model;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IRegistrationRL
    {
        public Users Register(RegistrationModel model, String role);

        public string Login(LoginModel model);
    }
}
