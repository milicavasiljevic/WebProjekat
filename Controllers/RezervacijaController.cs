using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace WebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RezervacijaController : ControllerBase
    {
        public SalonContext Context { get; set; }

        public RezervacijaController(SalonContext context)
        {
            Context = context;
        }

        [Route ("VratiRezervacije/{idSalona}/{username}")]
        [HttpGet]
        public async Task<ActionResult> VratiRezervacije(int idSalona, string username) 
        {
            try
            {
                if (idSalona < 0 || !Context.Saloni.Any(k => k.Id == idSalona))
                {
                    return BadRequest("Salon ne postoji");
                }

                return Ok(
                     await Context.Rezervacije
                     .Include(r=>r.RezervisaniTermin)
                     .ThenInclude(p=>p.Termin)
                     .Include(p=>p.RezervisaniTermin)
                     .ThenInclude(p=>p.Radnik)
                     .ThenInclude(u=>u.Usluga)
                     .Where(r=>r.Salon.Id==idSalona && r.Korisnik.Username.CompareTo(username)==0)
                     .ToListAsync()       
                );
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }

        [Route("DodajRezervaciju/{idSalona}/{idTermin}/{datum}/{idRadnik}/{korisnickoIme}")]
        [HttpPost]
        public async Task<ActionResult> DodajRezervaciju(int idSalona,int idTermin, string datum, int idRadnik, string korisnickoIme)
        {
            if(idSalona<0)
            {
                return BadRequest("Salon ne postoji!");
            }

            if (idRadnik < 0)
            {
                return BadRequest("Nije unet radnik");

            }
            if (datum == null)
            {
                return BadRequest("Zaboravili ste da unesete datum");
            }
            if (string.IsNullOrEmpty(korisnickoIme))
            {
                return BadRequest("Nema username-a!");

            }

            try
            {
                var termin = await Context.RadniciTermini
                .Where(p=>p.Radnik.Id==idRadnik && p.Termin.Id==idTermin
                && p.Datum.CompareTo(datum)==0)
                .FirstOrDefaultAsync();

                var korisnik=await Context.Korisnici
                .Where(p=>p.Username.CompareTo(korisnickoIme)==0)
                .FirstOrDefaultAsync();

                var salon=await Context.Saloni.Where(p=>p.Id==idSalona).FirstOrDefaultAsync();

                if (termin == null)
                    return BadRequest("Termin ne postoji");

                if (korisnik == null)
                {
                    return BadRequest("Ne postoji korisnik sa korisnickim imenom");
                }
                termin.Status=true;
                var rez=new Rezervacija();
                rez.Salon=salon;
                rez.RezervisaniTermin=termin;
                rez.Korisnik=korisnik;

                Context.Rezervacije.Add(rez);
                //korisnik.Rezervacije.Add(rez);
                salon.Rezervacije.Add(rez);
                await Context.SaveChangesAsync();

                return Ok($"Rezervisan je termin!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route ("OtkaziRezervaciju/{idRezervacije}")]
        [HttpDelete]
        public async Task<ActionResult> OtkaziRezervaciju(int idRezervacije) 
        {
            if (idRezervacije < 0)
                {
                    return BadRequest("Rezervacija ne postoji");
                }
            try
            {
                var rezervacija= await Context.Rezervacije.FindAsync(idRezervacije);
                if(rezervacija==null)
                {
                    return BadRequest("Nema trazene rezervacije!");
                }
                var termin=await Context.Rezervacije.Include(r=>r.RezervisaniTermin).Where(r=>r.Id==idRezervacije).FirstOrDefaultAsync();
                termin.RezervisaniTermin.Status=false;
                Context.Rezervacije.Remove(rezervacija);
                
                await Context.SaveChangesAsync();

                return Ok("Uspesno otkazana rezervacija!");
            }
            catch (Exception e)
            {
                return BadRequest("Doslo je do greske: " + e.Message);
            }
        }
    }
}