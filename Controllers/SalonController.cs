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
    public class SalonController : ControllerBase
    {
        public SalonContext Context { get; set; }

        public SalonController(SalonContext context)
        {
            Context = context;
        }

        [Route("DodajSalon")]
        [HttpPost]
        public async Task<ActionResult> DodajSalon([FromBody] Salon salon)
        {
            if (string.IsNullOrWhiteSpace(salon.Naziv) || salon.Naziv.Length > 50)
            {
                return BadRequest("Pogresno ime!");
            }
            if (string.IsNullOrEmpty(salon.Adresa))
            {
                return BadRequest("Pogresna adresa!");
            }
            try
            {
                Context.Saloni.Add(salon);
                await Context.SaveChangesAsync();
                return Ok($"Salon je dodat! ID: {salon.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiSalone")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiSalone()  //RADI
        {
            try
            {
                return Ok(await Context.Saloni.Select(p =>
                new
                {
                    p.Id,
                    p.Naziv,
                    p.Adresa

                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }

    }

}

     