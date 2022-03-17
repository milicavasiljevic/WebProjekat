import { Salon } from "./Salon.js";

export class Rezervacija {

    constructor(salon,id,usluga,datum,radnik,termin) {
        this.salon=salon;
        this.id = id;
        this.usluga=usluga;
        this.datum=datum;
        this.radnik=radnik;
        this.termin=termin;
        this.container=null;
    }
    upisiRezervaciju(host)
    {
        var tr = document.createElement("tr");
        host.appendChild(tr);
        this.container=tr;

        var td = document.createElement("td");
        td.innerHTML=this.usluga;
        tr.appendChild(td);

        var td = document.createElement("td");
        td.innerHTML=this.datum;
        tr.appendChild(td);

        var td = document.createElement("td");
        td.innerHTML=this.radnik;
        tr.appendChild(td);

        var td = document.createElement("td");
        td.innerHTML=this.termin;
        tr.appendChild(td);

        var td=document.createElement("td");
        var but=document.createElement("button");
        but.setAttribute("data-IndeksRezervacije",this.id);
        but.className="otkaziDugme";  
        but.innerHTML="Otkaži";
        but.onclick=(ev)=>{
            but.classList.add("Pritisnuto");
            this.otkaziRezervaciju(host);
        }
        td.appendChild(but);
        tr.appendChild(td);

       //host.appendChild(tr);
    }

    otkaziRezervaciju(host)
    {
        var dugme=host.querySelector(".Pritisnuto");
        var id=dugme.getAttribute("data-IndeksRezervacije");

        fetch("https://localhost:5001/Rezervacija/OtkaziRezervaciju/"+id,
        {
            method:'DELETE',
        })
        .then(p => p.text())
        .then(p=>console.log(p))
        alert("Termin uspesno otkazan!");
        dugme.classList.remove(".Pritisnuto");

        var rod=host.parentNode;
        rod.removeChild(host);
        var rod1=rod.parentNode;
        this.salon.vratiRezervacije(rod1);


    }
}