using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieStandApi.Data;
using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.Interfaces;
using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStand _cookieStandService;

        public CookieStandsController(ICookieStand context)
        {
            _cookieStandService = context;
        }

        // GET: api/CookieStands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookieStandDto>>> CookieStands()
        {
            try
            {
                return await _cookieStandService.GetCookieStands();
            }
            catch (Exception ex)
            {
                // Log the exception...
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/CookieStands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStandDto>> cookiestand(int id)
        {
            try
            {
                var cookieStand = await _cookieStandService.GetCookieStandById(id);

                if (cookieStand == null)
                {
                    return NotFound();
                }

                return cookieStand;
            }
            catch (Exception ex)
            {
                // Log the exception...
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // PUT: api/CookieStands/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CookieStandDto>> cookiestand(int id, CookieStandDto cookieStand)
        {
            if (id != cookieStand.Id)
            {
                return BadRequest();
            }

            try
            {
                return await _cookieStandService.Update(id, cookieStand);
            }
            catch (Exception ex)
            {
                // Log the exception...
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        // POST: api/CookieStands
        [HttpPost]
        public async Task<ActionResult<CookieStandDto>> cookiestand(CookieStandDto cookieStand)
        {
            try
            {
                return await _cookieStandService.Create(cookieStand);
            }
            catch (Exception ex)
            {
                // Log the exception...
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new cookie stand record");
            }
        }

        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookieStand(int id)
        {
            try
            {
                await _cookieStandService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception...
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }

}
