using System;
using System.Collections.Generic;
using Assignment2.Data.Models;
using Assignment2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultDao AdultDao;

        public AdultController(IAdultDao adultDao)
        {
            AdultDao = adultDao;
        }
       

        [HttpGet]
        public ActionResult<ICollection<Adult>> GetAdultAsync
        ()
        {
            try
            {
                IList<Adult> adults = AdultDao.Getadults();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public ActionResult<Adult> addAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = AdultDao.AddAdult(adult);
                return Created($"{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        public ActionResult RemoveAdult([FromQuery] int id)
        {

            AdultDao.RemoveAdult(id);


            return Ok();
        }
    }
}
