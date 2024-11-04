using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("Id")]
        public IActionResult GetByID([FromRoute] int Id)
        {
            var stock = _context.stocks.Find(Id);

            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}