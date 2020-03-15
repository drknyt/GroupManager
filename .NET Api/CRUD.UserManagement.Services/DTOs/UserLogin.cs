using CRUD.UserManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.UserManagement.Services.DTOs
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
