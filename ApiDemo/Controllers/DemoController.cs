using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly DemoContext _context;

        public DemoController(DemoContext context)
        {
            _context = context;

            if (_context.Demo.Count() == 0)
            {
                // Create a new Demo if collection is empty,
                // which means you can't delete all Demo.
                _context.Demo.Add(new Demo { Name = "Demo1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Demo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demo>>> GetDemo()
        {
            return await _context.Demo.ToListAsync();
        }
    }
}