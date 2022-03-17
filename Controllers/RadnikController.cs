using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace WebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadnikController : ControllerBase
    {
        public SalonContext Context { get; set; }

        public RadnikController(SalonContext context)
        {
            Context = context;
        }

        [Route("PreuzmiRadnike/{idSalona}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiRadnike(int idSalona)  
        {
            try
            {
                if (idSalona < 0 || !Context.Saloni.Any(k => k.Id == idSalona))
                {
                    return BadRequest("Salon ne postoji");
                }

                return Ok(
                    await Context.Radnici
                    .Where(k => k.Salon.Id == idSalona)
                    .Select(k =>
                        new
                        {
                            k.Ime,
                            k.Prezime,
                            k.Jmbg,
                            k.Usluga
                        }
                    ).ToListAsync()
                );
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }

        [Route("DodajRadnika/{idSalona}/{idUsluge}/{ime}/{prezime}/{jmbg}")]   
        [HttpPost]
        public async Task<ActionResult> DodajRadnika(int idSalona, int idUsluge, string ime, string prezime,string jmbg )
        {
            if(string.IsNullOrWhiteSpace(jmbg) || jmbg.Length!=13)
            {
                return BadRequest("Pogresan JMBG!");
            }
            if(string.IsNullOrWhiteSpace(ime) || ime.Length>50)
            {
                return BadRequest("Pogresno ime!");
            }
            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length>50)
            {
                return BadRequest("Pogresno prezime!");
            }
            try{
                var radnik=new Radnik();
                radnik.Jmbg=jmbg;
                radnik.Ime=ime;
                radnik.Prezime=prezime;

                var salon=Context.Saloni.Where(s => s.Id==idSalona).FirstOrDefault();
                if(salon==null)
                    return BadRequest("Nema salona!");
                radnik.Salon=salon;

                var usl=Context.Usluge.Where(u => u.Id==idUsluge).FirstOrDefault();
                if(usl==null)
                    return BadRequest("Nema usluge!");
                radnik.Usluga=usl;

                Context.Radnici.Add(radnik);
                salon.Radnici.Add(radnik); 
                await Context.SaveChangesAsync();

                return Ok(await Context.Radnici.Where(r =>r.Jmbg==jmbg).Select(p =>
                new
                {
                    p.Id,
                    p.Ime,
                    p.Prezime,
                    p.Jmbg,
                    p.Usluga,
                    p.Salon

                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
            
        }

        [Route ("RadniciPoUsluzi/{idSalona}/{idUsluge}")]
        [HttpGet]
        public async Task<ActionResult> RadniciPoUsluzi(int idSalona, int idUsluge) 
        {
            try
            {
                if (idSalona < 0 || !Context.Saloni.Any(k => k.Id == idSalona))
                {
                    return BadRequest("Salon ne postoji");
                }

                var radnici= await Context.RadniciTermini
                .Include(ra=>ra.Radnik)
                .ThenInclude(u=>u.Usluga)
                .Include(r=>r.Radnik)
                .ThenInclude(s=>s.Salon)
                .Include(p=>p.Termin)
                .Where(p=>p.Radnik.Salon.Id==idSalona && p.Radnik.Usluga.Id==idUsluge)
                .Select(p => new 
                {
                    Id = p.Radnik.Id,
                    Ime = p.Radnik.Ime,
                    Prezime = p.Radnik.Prezime
                }).Distinct().ToListAsync();


                return Ok(radnici);
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }


    }
}