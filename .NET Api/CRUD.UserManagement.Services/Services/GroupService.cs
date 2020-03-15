using CRUD.UserManagement.Domain;
using CRUD.UserManagement.Services.Interfaces;
using CRUD.UserManagement.Services.Repositories;
using CRUD.UserManagement.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using CRUD.UserManagement.Services.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CRUD.UserManagement.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;

        public GroupService(IGroupRepository groupRepository, IMapper mapper , IOptions<AppSettings> appSettings)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public List<GroupDTO> GetAll()
        {
            IEnumerable<Group> listOfGroups = this.groupRepository.GetAll();
            return mapper.Map<List<GroupDTO>>(listOfGroups);
        }

        public List<GroupDTO> GetUserGroups(int userId)
        {
            IEnumerable<Group> groups = this.groupRepository.GetUserGroups(userId);
            return mapper.Map<List<GroupDTO>>(groups);
        }

        public GroupDTO GetGroupById(int groupId)
        {
            Group group = this.groupRepository.GetGroupById(groupId);
            return mapper.Map<GroupDTO>(group);
        }

        public GroupDTO Add(GroupDTO groupDTO)
        {
            Group group = mapper.Map<Group>(groupDTO);
            return mapper.Map<GroupDTO>(this.groupRepository.Add(group));
        }

        public bool Delete(int groupId)
        {
            return this.groupRepository.Delete(groupId);
        }

        public GroupDTO Update(GroupDTO groupDTO)
        {
            Group group = mapper.Map<Group>(groupDTO);
            return mapper.Map<GroupDTO>(this.groupRepository.Update(group));
        }

        public bool AddUserGroup(int groupId, int userId)
        {
           return this.groupRepository.AddUserGroup(groupId, userId);
        }

        public bool RemoveUserGroup(int groupId, int userId)
        {
           return  this.groupRepository.RemoveUserGroup(groupId, userId);
        }
    }
}
