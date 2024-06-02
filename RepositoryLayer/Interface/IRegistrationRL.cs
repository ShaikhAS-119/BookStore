using ModelLayer.Model;
using RepositoryLayer.Repository;
using System;

namespace RepositoryLayer.Interface
{
    public interface IRegistrationRL
    {
        public Users Register(RegistrationModel model, String role);

        public string Login(LoginModel model);
    }
}
