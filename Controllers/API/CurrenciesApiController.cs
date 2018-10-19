using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteWebApi.Data;
using SQLiteWebApi.Models;

namespace SQLiteWebApi.Controllers.API
{
    [Produces("application/json")]
    [Route("api/CurrenciesApi")]
    [ApiController]
    public class CurrenciesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrenciesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrenciesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currency = await _context.Currencies.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        private bool CurrencyExists(int id)
        {
            return _context.Currencies.Any(e => e.CurrencyId == id);
        }
    }
}