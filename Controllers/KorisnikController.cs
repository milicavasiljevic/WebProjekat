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
    public class KorisnikController : ControllerBase
    {
        public SalonContext Context { get; set; }

        public KorisnikController(SalonContext context)
        {
            Context = context;
        }

        [Route("RegistrujSe/{idSalona}/{Ime}/{Prezime}/{email}/{sifra}")]
        [HttpPost]
        public async Task<ActionResult> DodatiKorisnika(int idSalona,string Ime, string Prezime, string email, string sifra)
        {
            if(idSalona<0)
            {
                return BadRequest("Nema salona!");
            }

            if (string.IsNullOrEmpty(Ime))
            {
                return BadRequest("Zaboravili ste da uneste ime");
            }
            if (string.IsNullOrEmpty(Prezime))
            {
                return BadRequest("Zaboravili ste da uneste prezime");
            }
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Zaboravili ste da uneste korisnicko ime");
            }
            if (string.IsNullOrEmpty(sifra))
            {
                return BadRequest("Zaboravili ste da uneste sifru");
            }
            if (sifra.Length < 8)
            {
                return BadRequest("Sifra mora imati minimum 8 karaktera");
            }
            var korisnik = await Context.Rezervacije
            .Include(s=>s.Salon)
            .Where(acc => acc.Salon.Id == idSalona)
            .Include(p=>p.Korisnik)
            .Where(p=>p.Korisnik.Username.CompareTo(email)==0)
            .FirstOrDefaultAsync();
            
            var salon=await Context.Saloni.Where(p=>p.Id==idSalona).FirstOrDefaultAsync();
            if (korisnik != null)
                return BadRequest("Korisnik sa unetim korisnickim imenom vec postoji");
            try
            {
                Korisnik k = new Korisnik
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    Username = email,
                    Sifra = sifra,
            

                };
                Context.Korisnici.Add(k);
                await Context.SaveChangesAsync();
                return Ok(k);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("UlogujSe/{idSalona}/{email}/{sifra}")]
        [HttpGet]
        public async Task<ActionResult> VratitiKorisnika(int idSalona, string email, string sifra)
        {

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Zaboravili ste da uneste korisnicko ime");
            }
            if (string.IsNullOrEmpty(sifra))
            {
                return BadRequest("Zaboravili ste da unesete sifru");
            }
            if (sifra.Length < 8)
            {
                return BadRequest("Sifra mora imati minimum 8 karaktera");
            }
            var korisnik = await Context.Rezervacije
                .Where(p=>p.Salon.Id==idSalona && p.Korisnik.Username.CompareTo(email)==0)
                .Include(k=>k.Korisnik)
                .FirstOrDefaultAsync();   
                if (korisnik == null)
                {
                    return BadRequest("Korisnik sa unetim korisnickim imenom ne postoji");
                }

            try
            {
                return Ok(korisnik);  

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzmeniKorisnika/{ime}/{prezime}/{username}/{sifra}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniKorisnika(string ime, string prezime, string username, string sifra)
        {

            if (string.IsNullOrEmpty(ime))
            {
                return BadRequest("Zaboravili ste da unesete ime!");
            }
            if (string.IsNullOrEmpty(prezime))
            {
                return BadRequest("Zaboravili ste da unesete prezime!");
            }
            if (string.IsNullOrEmpty(sifra))
            {
                return BadRequest("Zaboravili ste da unesete sifru!");
            }

            try
            {
                var korisnik = await Context.Korisnici
                .Where(p=>p.Username.CompareTo(username)==0)
                .FirstOrDefaultAsync();   
                if (korisnik == null)
                    return BadRequest("Korisnik sa unetim korisnickim imenom ne postoji");

                korisnik.Ime=ime;
                korisnik.Prezime=prezime;
                korisnik.Sifra=sifra;

                await Context.SaveChangesAsync();    

                return Ok(korisnik); 

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }
}
