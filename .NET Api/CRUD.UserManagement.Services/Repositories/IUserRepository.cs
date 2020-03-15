using System;
using System.Collections.Generic;
using System.Text;
using CRUD.UserManagement.Domain;

namespace CRUD.UserManagement.Services.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserById(int userId);
        User Add(User user);
        User Update(User user);
        User Delete(int userId);
       
    }
}
