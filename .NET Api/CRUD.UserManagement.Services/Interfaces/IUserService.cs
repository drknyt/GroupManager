using CRUD.UserManagement.Domain;
using CRUD.UserManagement.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.UserManagement.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetUserById(int userId);
        UserDTO Add(UserDTO user);
        UserDTO Update(UserDTO user);
        UserDTO Delete(int userId);
        UserDTO Authenticate(string username, string password);
    }
}
