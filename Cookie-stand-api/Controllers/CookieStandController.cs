using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookie_stand_api.Models;
using Cookie_stand_api.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookie_stand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandController : ControllerBase
    {

        private readonly ICookieStandService _cookieStandService;


        public CookieStandController(ICookieStandService cookieStandService)
        {
            _cookieStandService = cookieStandService;
        }


        // POST: api/cookiestand
        [HttpPost]
        public async Task<ActionResult<CookieStand>> CreateCookieStand(CookieStand cookieStand)
        {
            var createdCookieStand = await _cookieStandService.CreateCookieStand(cookieStand);
            return CreatedAtAction(nameof(GetCookieStand), new { id = createdCookieStand.Id }, createdCookieStand);
        }



        // GET: api/cookiestands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookieStand>>> GetCookieStands()
        {
            var cookieStands = await _cookieStandService.GetAllCookieStands();
            return Ok(cookieStands);
        }



        // GET: api/cookiestand/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStand>> GetCookieStand(int id)
        {
            var cookieStand = await _cookieStandService.GetCookieStand(id);
            if (cookieStand == null)
            {
                return NotFound();
            }
            return Ok(cookieStand);
        }




        // DELETE: api/cookiestand/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCookieStand(int id)
        {
            _cookieStandService.DeleteCookieStand(id);
            return NoContent();
        }



        // PUT: api/cookiestand/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CookieStand>> UpdateCookieStand(int id, CookieStand updatedCookieStand)
        {
            if (id != updatedCookieStand.Id)
            {
                return BadRequest();
            }
            var cookieStand = await _cookieStandService.UpdateCookieStand(id, updatedCookieStand);
            if (cookieStand == null)
            {
                return NotFound();
            }
            return Ok(cookieStand);
        }





    }
}
