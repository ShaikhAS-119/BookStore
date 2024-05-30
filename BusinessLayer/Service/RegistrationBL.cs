using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class RegistrationBL : IRegistrationBL
    {
        private readonly IRegistrationRL _registrationRL;
        public RegistrationBL(IRegistrationRL registrationRL) 
        { 
            _registrationRL = registrationRL;
        }

        public Users Register(RegistrationModel model, String role)
        {
            return _registrationRL.Register(model, role);
        }

        public string Login(LoginModel model)
        {
            return _registrationRL.Login(model);
        }
    }
}
