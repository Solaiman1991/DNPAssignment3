using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data.Models;
using Assignment2.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultFileContext AdultFileContext;

        public AdultController(IAdultFileContext adultFileContext)
        {
            AdultFileContext = adultFileContext;
        }
        // [FromQuery] string? jobTitle,[FromQuery] string? salary,[FromQuery]string? eyeColor, [FromQuery]int? age,[FromQuery]int? weight, [FromQuery]int? height,[FromQuery]string? sex
        // [HttpGet]
        // public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery]int? id, [FromQuery] string? firstName,[FromQuery]string? lastName)
        // {
        //     try
        //     {
        //         IList<Adult> adults = await adultService.Getadults();
        //         return Ok(adults);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         return StatusCode(500, e.Message);
        //     }
        // }


        [HttpGet]
        public async Task<ActionResult<ICollection<Adult>>> GetAdultAsync
        (
            [FromQuery] string firstname,
            [FromQuery] string lastname,
            [FromQuery] string jobTitle,
            [FromQuery] string hairColor,
            [FromQuery] string sex,
            [FromQuery] int? age,
            [FromQuery] int? id

        )
        {
            try
            {
                IList<Adult> adults = await AdultFileContext.Getadults();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Adult>> addAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await AdultFileContext.AddAdult(adult);
                return Created($"{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        public ActionResult RemoveAdult([FromQuery] int Id)
        {
            Adult adultToRemove;
            try
            {
                adultToRemove = AdultFileContext.Adults.First(a => a.Id == Id);

            }
            catch (Exception e)
            {
                return NotFound();
            }

            AdultFileContext.RemoveAdult(adultToRemove);


            return Ok();
        }
    }
}
