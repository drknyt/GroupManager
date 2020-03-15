using CRUD.UserManagement.Domain;
using CRUD.UserManagement.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.UserManagement.Services.Interfaces
{
    public interface IGroupService
    {
        List<GroupDTO> GetAll();
        GroupDTO GetGroupById(int groupId);
        List<GroupDTO> GetUserGroups(int userId);
        GroupDTO Add(GroupDTO group);
        GroupDTO Update(GroupDTO group);
        bool Delete(int groupId);
        bool AddUserGroup(int groupId, int userId);
        bool RemoveUserGroup(int groupId, int userId);
    }
}
