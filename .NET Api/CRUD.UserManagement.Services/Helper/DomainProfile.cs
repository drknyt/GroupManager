using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CRUD.UserManagement.Domain;
using CRUD.UserManagement.Services.DTOs;

namespace CRUD.UserManagement.Services.Helper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User,UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<GroupDTO, Group>();
            CreateMap<Group, GroupDTO>();
        }
    }
}
