using CRUD.UserManagement.Services.Interfaces;
using CRUD.UserManagement.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.User.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List of all users</returns>
        // GET api/values
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(this.userService.GetAll());
        }

        /// <summary>
        /// Get User By Id 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// User whose Id match with the parameter
        /// </returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            UserDTO user =  this.userService.GetUserById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>user who recently added</returns>
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO)
        {
            UserDTO user =  this.userService.Add(userDTO);
            return Ok(user);
        }

        /// <summary>
        /// Update an exiting user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>user who recently updated </returns>
        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] UserDTO userDTO)
        {
            UserDTO user =  this.userService.Update(userDTO);
            return Ok(user);
        }

        /// <summary>
        /// delete user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok in case no exception fire</returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            UserDTO user = this.userService.Delete(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserLogin userDTO)
        {
            var user = userService.Authenticate(userDTO.UserName, userDTO.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
