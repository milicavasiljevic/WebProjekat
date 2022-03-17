import { Salon } from "./Salon.js";

export class Korisnik {
    constructor(ime,prezime,username,sifra,salon) {
        this.ime = ime;
        this.prezime = prezime;
        this.username = username;
        this.sifra = sifra;
        this.kont = null;
        this.salon = salon;
    }
   
}