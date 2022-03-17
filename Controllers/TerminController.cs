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
    public class TerminController : ControllerBase
    {
        public SalonContext Context { get; set; }

        public TerminController(SalonContext context)
        {
            Context = context;
        }

        [Route("PreuzmiTermine")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiTermine()  
        {
            try
            {
                return Ok(await Context.Termini.Select(p =>
                new
                {
                    p.Id,
                    p.VremeOd,
                    p.VremeDo

                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }

        [Route("PreuzmiDatume")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiDatume()  //PROVERI!!!!!!!!!
        {
            try
            {
                return Ok( await Context.RadniciTermini.Select(p=>
                new{
                    p.Datum
                }).ToListAsync());

            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }
        [Route("TerminiPoRadniku/{idRadnika}/{datum}")]
        [HttpGet]
        public async Task<ActionResult> TerminiPoRadniku(int idRadnika, string datum)
        {
            try{
                var termini=Context.RadniciTermini.Include(r=>r.Radnik).Where(r=>r.Radnik.Id==idRadnika && r.Datum.CompareTo(datum)==0);
                return Ok( await termini.Select(p=>
                new{
                    p.Id,
                    p.Status
                }).ToListAsync());

            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }
       


    }
}