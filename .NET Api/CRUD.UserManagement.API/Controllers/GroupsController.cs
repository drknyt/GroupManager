using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.UserManagement.Services.Interfaces;
using CRUD.UserManagement.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.User.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;
        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns>List of all groups</returns>
        // GET api/values
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(this.groupService.GetAll());
        }

        /// <summary>
        /// Get Group By Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Group whose Id match with the parameter
        /// </returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            GroupDTO movie = this.groupService.GetGroupById(id);

            if (movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Add New Movie
        /// </summary>
        /// <param name="movieDTO"></param>
        /// <returns>movie who recently added</returns>
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] GroupDTO groupDTO)
        {
            GroupDTO movie = this.groupService.Add(groupDTO);
            return Ok(movie);
        }

        /// <summary>
        /// Update an exiting movie
        /// </summary>
        /// <param name="movieDTO"></param>
        /// <returns>movie who recently updated </returns>
        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] GroupDTO groupDTO)
        {
            GroupDTO group = this.groupService.Update(groupDTO);
            return Ok(group);
        }

        /// <summary>
        /// delete movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok in case no exception fire</returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (this.groupService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Get All Groups
        /// </summary>
        /// <returns>List of all movies</returns>
        // GET api/values
        [HttpGet("userGroups/{userId}")]
        public ActionResult GetUserGroups(int userId)
        {
            return Ok(this.groupService.GetUserGroups(userId));
        }

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns>List of all movies</returns>
        // GET api/values
        [HttpPost("AddUserGroup/{userId}/{groupId}")]
        public ActionResult AddUserGroup(int userId, int groupId)
        {
            if (this.groupService.AddUserGroup(groupId, userId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns>List of all movies</returns>
        // GET api/values
        [HttpDelete("DeleteUserGroup/{userId}/{movieId}")]
        public ActionResult DeleteUserGroup(int userId, int groupId)
        {
            if (this.groupService.RemoveUserGroup(groupId, userId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
