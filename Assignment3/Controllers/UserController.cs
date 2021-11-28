using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assignment2.Data.Models;
using Assignment2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserDao UserDao;

        public UserController(IUserDao userDao)
        {
            UserDao = userDao;
        }

        // [HttpGet]
        // public ActionResult<ICollection<User>> GetUserAsync()
        // {
        //     try
        //     {
        //         IList<User> users = UserDao.GetUsers();
        //         return Ok(users);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         return StatusCode(500, e.Message);
        //     }
        // }

        [HttpGet]
        public ActionResult<User> ValidateLogin([FromQuery] string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("Enter username");
            }

            if (string.IsNullOrEmpty(password))
            {
                return BadRequest("Enter password");
            }

            try
            {
                return Ok(UserDao.ValidateUser(userName, password));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult<User> addUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("kommer vi her i add user postReq");
                return BadRequest(ModelState);
                
            }

            try
            {
                User added = UserDao.AddUser(user);
                Console.WriteLine("vi kommer nok ikk her");

                return Created($"{added.UserName}", added);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}