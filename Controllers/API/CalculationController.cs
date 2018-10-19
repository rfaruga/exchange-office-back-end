using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteWebApi.Models;
using SQLiteWebApi.Data;

namespace SQLiteWebApi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalculationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrenciesApi/5
        [HttpGet("{value}/{initialCurrency}/{destinationCurrency}")]
        public async Task<IActionResult> Calculate([FromRoute] double value, [FromRoute] CurrencyName initialCurrency, [FromRoute] CurrencyName destinationCurrency)
        {
            var initCurrency = await _context.Currencies.FindAsync((int)initialCurrency);
            var destCurrency = await _context.Currencies.FindAsync((int)destinationCurrency);

            return Ok(value * (initCurrency.ExchangeRate / destCurrency.ExchangeRate));
        }
    }
}