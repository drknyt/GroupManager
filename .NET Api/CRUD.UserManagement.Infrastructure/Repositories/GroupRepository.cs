using CRUD.UserManagement.Domain;
using CRUD.UserManagement.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CRUD.UserManagement.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly UserManagementContext userManagementContext;

        public GroupRepository(UserManagementContext userManagementcontext)
        {
            this.userManagementContext = userManagementcontext ?? throw new ArgumentNullException(nameof(userManagementcontext));
        }

        public IEnumerable<Group> GetAll()
        {
            return userManagementContext.Groups;
        }

        public IEnumerable<Group> GetUserGroups(int userId)
        {
            return userManagementContext.Users.Include(um => um.UserGroups).ThenInclude(m => m.Group).FirstOrDefault(u => u.UserId == userId)
                .UserGroups.Select(a => a.Group);
        }

        public Group GetGroupById(int groupId)
        {
            return userManagementContext.Groups.FirstOrDefault(a => a.GroupId == groupId);
        }

        public Group Add(Group group)
        {
            userManagementContext.Groups.Add(group);
            userManagementContext.SaveChanges();
            return group;
        }

        public bool Delete(int groupId)
        {
            var result = userManagementContext.Groups.SingleOrDefault(u => u.GroupId == groupId);
            if (result != null)
            {
                userManagementContext.Groups.Remove(result);
                userManagementContext.SaveChanges();
            }
            return true;
        }

        public Group Update(Group group)
        {
            var result = userManagementContext.Groups.SingleOrDefault(u => u.GroupId == group.GroupId);

            if (result != null)
            {
                result.GroupName = group.GroupName;
                result.GroupAdmin = group.GroupAdmin;
                userManagementContext.SaveChanges();
            }

            return result;
        }

        public bool AddUserGroup(int groupId, int userId)
        {
            try
            {
                UserGroup userGroup = new UserGroup();

                userGroup.GroupId = groupId;
                userGroup.UserId =  userId;

                userManagementContext.Users.FirstOrDefault(u => u.UserId == userId).UserGroups.Add(userGroup);
                userManagementContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveUserGroup(int groupId, int userId)
        {
            try
            {
                var userGroup = userManagementContext.Users.Include(u => u.UserGroups).FirstOrDefault(u => u.UserId == userId).UserGroups.FirstOrDefault(a => a.UserId == userId && a.GroupId == groupId);
                userManagementContext.Users.FirstOrDefault(u => u.UserId == userId).UserGroups.Remove(userGroup);
                userManagementContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
