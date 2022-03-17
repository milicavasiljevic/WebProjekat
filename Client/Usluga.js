import { Salon } from "./Salon.js";

export class Usluga {

    constructor(id,naziv,cena) {
        this.id = id;
        this.naziv = naziv;
        this.cena = cena;
        this.container=null;
    }
    upisiUslugu(host)
    {
        let red=document.createElement("tr");
        host.appendChild(red);
        this.container=red;

        let el=document.createElement("td");
        el.innerHTML=this.naziv;
        red.appendChild(el);

        let el1=document.createElement("td");
        el1.innerHTML=this.cena;
        red.appendChild(el1);
    }
}