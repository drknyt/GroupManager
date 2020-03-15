using System;
using System.Collections.Generic;
using System.Text;
using CRUD.UserManagement.Domain;

namespace CRUD.UserManagement.Services.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group GetGroupById(int groupId);
        IEnumerable<Group> GetUserGroups(int userId);
        Group Add(Group group);
        Group Update(Group group);
        bool Delete(int groupId);
        bool AddUserGroup(int movieId , int userId);
        bool RemoveUserGroup(int movieId, int userId);
    }
}