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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IMapper mapper , IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public List<UserDTO> GetAll()
        {
            IEnumerable<User> listOfUsers = this.userRepository.GetAll();
            return mapper.Map<List<UserDTO>>(listOfUsers);
        }

        public UserDTO GetUserById(int userId)
        {
            User user = this.userRepository.GetUserById(userId);
            return mapper.Map<UserDTO>(user);
        }

        public UserDTO Add(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);
            return mapper.Map<UserDTO>(this.userRepository.Add(user));
        }

        public UserDTO Delete(int userId)
        {
            return mapper.Map<UserDTO>(this.userRepository.Delete(userId));
        }

        public UserDTO Update(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);
            return mapper.Map<UserDTO>(this.userRepository.Update(user));
        }

        public UserDTO Authenticate(string username, string password)
        {
            var user = this.GetAll().SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            user.Token = tokenString;

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
