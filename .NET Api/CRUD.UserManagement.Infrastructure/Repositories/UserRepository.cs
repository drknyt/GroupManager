using CRUD.UserManagement.Domain;
using CRUD.UserManagement.Services.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementContext userManagementContext;

        public UserRepository(UserManagementContext userManagementcontext)
        {
            this.userManagementContext = userManagementcontext ?? throw new ArgumentNullException(nameof(userManagementcontext));
        }

        public IEnumerable<User> GetAll()
        {
            return userManagementContext.Users;
        }

        public User GetUserById(int userId)
        {
            return userManagementContext.Users.FirstOrDefault(a => a.UserId == userId);
        }

        public User Add(User user)
        {
            userManagementContext.Users.Add(user);
            userManagementContext.SaveChanges();
            return user;
        }

        public User Delete(int userId)
        {
            var result = userManagementContext.Users.SingleOrDefault(u => u.UserId == userId);
            if(result !=null)
            {
                userManagementContext.Remove(result);
                userManagementContext.SaveChanges();
            }
            return result;
        }

        public User Update(User user)
        {
            var result = userManagementContext.Users.SingleOrDefault(u=>u.UserId ==user.UserId);

            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Password = user.Password;
                userManagementContext.SaveChanges();
            }

            return result;
        }
    }
}
