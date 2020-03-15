using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.UserManagement.Services.DTOs
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int GroupAdmin { get; set; }
    }
}
