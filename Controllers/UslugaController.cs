using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebProjekat.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UslugaController : ControllerBase
    {
        public SalonContext Context { get; set; }

        public UslugaController(SalonContext context)
        {
            Context = context;
        }

        [Route("VratiUsluge/{idSalon}")]
        [HttpGet]
        public async Task<ActionResult> VratiUsluge(int idSalon)  
        {
            try
            {
             
                var ret = await Context.SaloniUsluge.Where(p => p.Salon.Id==idSalon).Include(u => u.Usluga).ToListAsync();
                return Ok(ret);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        

        [Route("Usluge")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiUsluge()  
        {
            try
            {
                return Ok(await Context.Usluge.Select(p =>
                new
                {
                    p.Id,
                    p.Naziv
                    
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }

    }
}