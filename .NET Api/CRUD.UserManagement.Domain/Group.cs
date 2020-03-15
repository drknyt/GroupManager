using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD.UserManagement.Domain
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();

        public int GroupAdmin { get; set; }

    }
}
