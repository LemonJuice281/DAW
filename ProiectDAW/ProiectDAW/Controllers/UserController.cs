using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Models;
using ProiectDAW.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private BDRepo bdr = new BDRepo();

        [HttpGet]
        [Route("all")]
        public IActionResult GetUsers()
        {
            var users = bdr.GetObjects<User>();

            return Ok(users);
        }

        [HttpGet]
        [Route("{userName}")]
        public IActionResult GetUsers(string userName)
        {
            var users = bdr.GetObjects<User>();

            return Ok(users.Where(x => x.UserName == userName).FirstOrDefault());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            var newUsre = bdr.PostObject<User>(user);

            if (newUsre == null)
                return BadRequest("Could not create user");

            return Ok(user);
        }

        [HttpPost]
        [Route("{userName}")]
        public IActionResult PutUser([FromBody] User user)
        {
            var updatedUser = bdr.PutObject<User>(user);

            if (updatedUser == null)
                return BadRequest("Could not update user");

            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("{username}/{password}")]
        public IActionResult DeleteUser(string userName, string password)
        {
            var getuser = bdr.GetUser(userName, password);

            bdr.DeleteObject<User>(getuser);

            return NoContent();
        }

    }
}
