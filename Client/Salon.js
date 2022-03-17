import { Korisnik } from "./Korisnik.js";
//import { Usluga } from "./Usluga.js";
import {Radnik} from "./Radnik.js";
import { Div } from "./Div.js";
import { Rezervacija } from "./Rezervacija.js";


export class Salon {

    constructor(id, naziv, listaUsluga,listaDatuma, listaTermina) {
        this.id = id;
        this.naziv = naziv;
        this.kont = null;
        this.datum;
        this.korisnik=null;
        this.listaRadnika = [];
        this.listaUsluga=listaUsluga;
        this.listaDatuma=listaDatuma;
        this.listaTermina=listaTermina;
    }

    crtajSalon(host) {


        this.kont=document.createElement("div");
        this.kont.className="divGlavniKontejner";
        host.appendChild(this.kont);

        var red2 = document.createElement("div");
        red2.className = "KorisnikZaglavlje";
        var labela = document.createElement("label");
        labela.className = "KorisnikZaglavljeLabela";
        labela.innerHTML = "Prijava";
        red2.appendChild(labela);



        labela.onclick = (ev) => {
            if(this.korisnik!=null)
            {
                alert("Vec ste prijavljeni kao:"+this.korisnik.username);
                return;
            }
            this.crtajKorisnikaSkraceno(glavniDeo);
        }

        labela = document.createElement("label");
        labela.className = "KorisnikZaglavljeLabela1";
        labela.innerHTML = "Registracija";
        red2.appendChild(labela);

        labela.onclick = (ev) => {
            if(this.korisnik!=null)
            {
                alert("Vec ste prijavljeni kao:"+this.korisnik.username);
                return;
            }
            this.crtajKorisnika(glavniDeo);
        }

        labela=document.createElement("label");
        labela.className="KorisnikZaglavljeLabela1";
        labela.innerHTML="Izmeni profil";
        red2.appendChild(labela);

        labela.onclick = (ev) =>{ 
            if(this.korisnik==null)
            {
                alert("Prijavite se ili se registrujte!");
                return;
            }
            this.formaIzmena(glavniDeo);
            }

        labela=document.createElement("label");
        labela.className="KorisnikZaglavljeLabela1";
        labela.innerHTML="Odjavi se";
        red2.appendChild(labela);

        labela.onclick = (ev) =>{ 
            if(this.korisnik==null)
            {
                alert("Prijavite se ili se registrujte!");
                return;
            }
            this.korisnik=null;
            window.location.reload();

            alert("Uspesno ste se odjavili!");
            }    

        this.kont.appendChild(red2);

        var red = document.createElement("h1");
        red.innerHTML = this.naziv;
        red.className = "Naziv";
        this.kont.appendChild(red);

        let glavniDeo = document.createElement("div");
        glavniDeo.className = "GlavniKontejner";
        this.kont.appendChild(glavniDeo);


        this.prikaziCenovnik(glavniDeo);

        this.crtajRezervaciju(glavniDeo);

        this.crtajMojeRezervacije(glavniDeo);

    }
    

    napraviCenovnikTabelu(host) {
        var teloTabele = host.querySelector(".TabelaCenovnik");

        if (teloTabele !== null) {
            var roditelj = teloTabele.parentNode;
            roditelj.removeChild(teloTabele);
        }


        teloTabele = document.createElement("tbody");
        teloTabele.className = "TabelaCenovnik";
        host.appendChild(teloTabele);
        let red=document.createElement("tr");
        teloTabele.appendChild(red);

        let h=document.createElement("th");
        h.innerHTML="Usluga";
        red.appendChild(h);
        let ha=document.createElement("th");
        ha.innerHTML="Cena";
        red.appendChild(ha);


        return teloTabele;
    }

    dodajUTabelu(tabela, naziv, cena) {
        var tr = document.createElement("tr");
        tr.className = "cenTabela";

        var td = document.createElement("td");
        td.className = "cenTabela";
        td.innerHTML = naziv;
        tr.appendChild(td);

        var td1 = document.createElement("td");
        td1.className = "cenTabela";
        td1.innerHTML = cena;
        tr.appendChild(td1);


        tabela.appendChild(tr);
    }
    prikaziCenovnik(host) {
        let cenovnikForma = document.createElement("div");
        host.appendChild(cenovnikForma);
        cenovnikForma.className = "CenovnikForma";
        let naslov = document.createElement("div");
        naslov.className = "Cenovnik";
        naslov.innerHTML = "Cenovnik";
        cenovnikForma.appendChild(naslov);
        

        let el = document.createElement("div");
        el.className = "TableRow";
        cenovnikForma.appendChild(el);
        let tabela = this.napraviCenovnikTabelu(el);
        

        this.listaUsluga.forEach(el => {
            el.upisiUslugu(tabela);
        });
        
    }

    crtajRezervaciju(host) {
        var Rezervacija = document.createElement("div");
        Rezervacija.className = "Rezervacija";
        host.appendChild(Rezervacija);
        
        //console.log(this.listaUsluga);
        var red0 = document.createElement("div");
        red0.className = "Red0";
        var labela = document.createElement("labela");
        labela.innerHTML = "zakaži termin:";
        red0.appendChild(labela);
        Rezervacija.appendChild(red0);


        var red = document.createElement("div");
        red.className = "Red1";
        var labela = document.createElement("label");
        labela.innerHTML = "Usluga:";
        red.appendChild(labela);

        var se = document.createElement("select");
        se.className = "comboBox2";
        red.appendChild(se);


        Rezervacija.appendChild(red);

        //console.log(this.listaUsluga[0].vratiNaziv());

       // console.log(this.listaUsluga[0]);
       var op = document.createElement("option");
       op.innerHTML = "Odaberite uslugu";
       op.value = 0;
       se.appendChild(op);
        this.listaUsluga.forEach(p => {
            op = document.createElement("option");
            op.innerHTML = p.naziv;
            //console.log(op.innerHTML);
            op.value = p.id;
            se.appendChild(op);
        });
        red = document.createElement("div");
        red.className = "Red2";
        labela = document.createElement("label");
        labela.innerHTML = "Datum:";
        var se1 = document.createElement("select");
        se1.className = "comboBox3";
        var op = document.createElement("option");
        op.innerHTML = "Unesite datum";
        op.value = 0;
        se1.appendChild(op);
        red.appendChild(labela);
        red.appendChild(se1);
        Rezervacija.appendChild(red);
        //console.log(this.listaDatuma);
        //console.log(this.listaDatuma[0]);
        let op1;
        this.listaDatuma.forEach((p,index) => {

            op1 = document.createElement("option");
            op1.innerHTML = p;
            console.log(op.innerHTML);
            op1.value = index+1;
            se1.appendChild(op1);

        });

        se1.value = 0;
        se.value = 0; 
        let btnOK=document.createElement("button");


        btnOK.onclick=(ev)=>{
            if(this.korisnik==null)
            {
                alert("Prijavite se ili se registrujte kako biste zakazali termin!");
                return;
            }
            console.log(this.korisnik.username);
            this.crtajTermine(Rezervacija)};
        btnOK.className="dugmeOK";
        btnOK.innerHTML="OK";
        Rezervacija.appendChild(btnOK);

       



    }
    async crtajTermine(host)
    {
        let nadjiDiv1=host.querySelector(".Red1");
        let usluga=nadjiDiv1.querySelector("select");
        let idUsluge = usluga.options[usluga.selectedIndex].value; 
        if(idUsluge==0)
        {
            alert("Niste odabrali uslugu!");
            return;
        }
        console.log("PROBA");   
        console.log(idUsluge);

        let nadjiDiv2=host.querySelector(".Red2");
        let dat=nadjiDiv2.querySelector("select");
        let datum=dat.options[dat.selectedIndex].innerText;
        this.datum=datum;
        if(dat.options[dat.selectedIndex].value==0)
        {
            alert("Niste odabrali datum!");
            return;
        }
        console.log(datum);

        let listaRad=[];

        var p = await fetch("https://localhost:5001/Radnik/RadniciPoUsluzi/"+ this.id +"/"+idUsluge);  
        let i=0;
        var data = await p.json();
        data.forEach(element => {

            var rad=new Radnik(element.id, element.ime, element.prezime);
            this.listaRadnika[i]=element.id;
            i++;
            listaRad.push(rad);

        });

        var terminiTabela = host.querySelector(".terminiTabela");
        if (terminiTabela !== null) {
            var roditelj = terminiTabela.parentNode;
            roditelj.removeChild(terminiTabela);
        }
        var polja=host.querySelector(".Polja");
        if (polja !== null) {
            var roditelj = polja.parentNode;
            roditelj.removeChild(polja);
        }
        

        polja=document.createElement("div");
        polja.className="Polja";
        let lab=document.createElement("label");
        lab.innerHTML="Zauzet termin:";
       // lab.className="zauzetTermin";
        let polje1=document.createElement("div");
        polje1.className="zauzetTermin1";
        polja.appendChild(lab);
        polja.appendChild(polje1);

        lab=document.createElement("label");
        lab.innerHTML="Slobodan termin:";
        //lab.className="slobodanTermin";
        let polje2=document.createElement("div");
        polje2.className="slobodanTermin1";
        polja.appendChild(lab);
        polja.appendChild(polje2);
        

        var di=host.querySelector(".zakaziDiv");
        if (di !== null) {
            var roditelj = di.parentNode;
            roditelj.removeChild(di);
        }
        var divZakazi=document.createElement("div");
       // div.className="zakaziDiv";

        terminiTabela = document.createElement("div");
        terminiTabela.className = "terminiTabela";
        host.appendChild(terminiTabela);
        host.appendChild(divZakazi);
        host.appendChild(polja);              


        let red = document.createElement("tr");
        terminiTabela.appendChild(red);

        let h = document.createElement("th");
        h.className = "terminiHeder";
        h.innerHTML = "";
        red.appendChild(h);
        this.listaTermina.forEach((el, index) => {
            let h = document.createElement("th");
            h.className = "terminiHeder";
            h.innerHTML = this.listaTermina[index].vremeOd + "-" + this.listaTermina[index].vremeDo;
            red.appendChild(h);
        });

    

        listaRad.forEach((el, index) => {
            let ime = listaRad[index].ime + " " + listaRad[index].prezime;
            console.log(ime);
            //lista termina za svakog radnika po datumu i njihov status
            let terminiRadnik = [];
            fetch("https://localhost:5001/Termin/TerminiPoRadniku/"+this.listaRadnika[index]+"/"+datum)
            .then(p => {
                if(p.ok){
                    p.json().then(data => {
                        data.forEach(termin =>
                            {
                                terminiRadnik.push(termin.status);
                            });
                            console.log(terminiRadnik);
                        this.addRow(host,divZakazi, ime, this.listaRadnika[index],terminiRadnik);
                        })
                    }
                    else
                    {
                        p.text().then(data=>
                            {

                                alert(data);
                            })
                    }
               });

        })
    }

        addRow(host, divZakazi,radnik, indRadnik, terminiRadnik)
        {
            console.log(terminiRadnik);
            var table = host.querySelector(".terminiTabela");  
            var tr = document.createElement("tr");
            var td = document.createElement("th");
            //td.className="radnici";
            td.innerText = radnik;
            tr.appendChild(td);

            
            for(let i=0;i<terminiRadnik.length;i++)
            {
                if(terminiRadnik[i]==false)
                {
                    //var div=document.createElement("div");
                    //div.className="slobodanTermin";
                    var td = document.createElement("td");
                   

                    var div=new Div(this,indRadnik,i+1,this.korisnik.username);
                    console.log(indRadnik);
                    div.crtajDivSlobodan(table,td,divZakazi);

                }
                else
                {
                    var td = document.createElement("td");
                    var div=new Div(this,indRadnik,i+1, this.korisnik.username);
                    console.log(indRadnik);
                    div.crtajDivZauzet(td);
                  
                }
                tr.appendChild(td);
            }
            table.appendChild(tr);
        }

        crtajMojeRezervacije(host){

            var divzadugme=document.createElement("div");
            divzadugme.className="DivZaDugme";

            var novaForma=document.createElement("div");
            novaForma.className="MojeRezervacije";

            var divzadugme=document.createElement("div");
            divzadugme.className="DivZaDugme";

            var but=document.createElement("button");
            but.innerHTML="MOJE REZERVACIJE";
            but.className="dugmeRez";
            divzadugme.appendChild(but);
            novaForma.appendChild(divzadugme);

            /*var divzatabelu=document.createElement("div");
            divzatabelu.className="DivZaTabelu";
            novaForma.appendChild(divzatabelu);*/
            but.onclick=(ev)=>{
                if(this.korisnik==null)
                {
                    alert("Prijavite se kako biste pregledali rezervacije!");
                    return;
                }
    
                this.vratiRezervacije(novaForma);             
            }
            host.appendChild(novaForma);



        }

        crtajKorisnika(host) {
            /* let pom = this.salon.querySelector(".AdminForma");
            
             if (pom !== null){
                 let rod= pom.parentNode;
                 rod.removeChild(pom);
             }*/
           
             var korisnikForma = host.querySelector(".KorisnikForma");
             if (korisnikForma !== null) {
                 var rod = korisnikForma.parentNode;
                 rod.removeChild(korisnikForma);
             }
     
             korisnikForma = document.createElement("div");
             korisnikForma.className = "KorisnikForma";
             //this.kont = korisnikForma;
             host.appendChild(korisnikForma);
     
     
             
             var pod = ["Ime", "Prezime"];
     
     
     
             var red = document.createElement("div");
             red.className = "KorisnikRed";
     
             var labela = document.createElement("label");
             labela.className = "KorisnikLabela"
     
     
     
             pod.forEach(p => {
                 red = document.createElement("div");
                 red.className = "KorisnikRed";

                 labela = document.createElement("label");
                 labela.innerHTML = p + ":";
                 labela.className = "KorisnikLabela"
                 let tb = document.createElement("input");
     
                 tb.setAttribute("type", "text");
                 tb.className = "KorisnikTextBox" + p;
     
                 red.appendChild(labela);
                 red.appendChild(tb);

                 korisnikForma.appendChild(red);
     
             });
     
     
     
             this.crtajPolja(korisnikForma);
     
     
     
     
     
             var btnRegistrujSe = document.createElement("button");
             btnRegistrujSe.onclick = (ev) => this.registracija(korisnikForma);
             btnRegistrujSe.innerHTML = "Registruj se";
     
             red = document.createElement("div");
             red.className = "KorisnikDugmici";
     
             red.appendChild(btnRegistrujSe);
             korisnikForma.appendChild(red);
         }

         crtajPolja(host) {



            var pod = ["username", "sifra"];
    
    
    
            var red = document.createElement("div");
            red.className = "KorisnikRed";
    
            var labela = document.createElement("label");
            labela.className = "KorisnikLabela"
    
    
    
            pod.forEach(p => {
                red = document.createElement("div");
                red.className = "KorisnikRed";

                labela = document.createElement("label");
                labela.innerHTML = p + ":";
                labela.className = "KorisnikLabela";

                let tb = document.createElement("input");
    
                if (p === "sifra")
                    tb.setAttribute("type", "password");
                else
                    tb.setAttribute("type", "text");
                tb.className = "KorisnikTextBox" + p;

                red.appendChild(labela);
                red.appendChild(tb);

                host.appendChild(red);
    
            });
    
    
    
        }
        crtajKorisnikaSkraceno(host) {
            var korisnikForma = host.querySelector(".KorisnikForma");
            if (korisnikForma !== null) {
                var rod = korisnikForma.parentNode;
                rod.removeChild(korisnikForma);
            }
    
            korisnikForma = document.createElement("div");
            korisnikForma.className = "KorisnikForma";
            //this.kont = korisnikForma;
            host.appendChild(korisnikForma);
    
            this.crtajPolja(korisnikForma);
    
    
            var btnUlogujSe = document.createElement("button");
            btnUlogujSe.onclick = (ev) => this.logovanje(korisnikForma);
            btnUlogujSe.innerHTML = "Prijavi se";
    
    
    
            var red = document.createElement("div");
            red.className = "KorisnikDugmici";
            red.appendChild(btnUlogujSe);
    
            korisnikForma.appendChild(red);
    
        }
     
async logovanje(host) {

            let email; let sifra;

            if (host.querySelector(".KorisnikTextBoxusername").value !== "")
                email = host.querySelector(".KorisnikTextBoxusername").value;        
            else {
                alert("Nije uneto korisnicko ime");
                return;
            }
            if (host.querySelector(".KorisnikTextBoxsifra").value !== "")
                sifra = host.querySelector(".KorisnikTextBoxsifra").value;
            else {
                alert("Nije uneta sifra");
                return;
            }
    
       

        var korisnik; 

        fetch("https://localhost:5001/Korisnik/UlogujSe/" + this.id +"/" + email +"/"+ sifra)
        .then(p => {
            if(p.ok){
                    p.json().then(data => {
                        if(sifra==data.korisnik.sifra){

                            korisnik=new Korisnik(data.korisnik.ime,data.korisnik.prezime,data.korisnik.username,data.korisnik.sifra, this);
                            this.korisnik=korisnik;
                            alert("Uspesno ste se ulogovali!");
                           // var rod=host.querySelector(".KorisnikForma");
                            var roditelj=host.parentNode;
                            roditelj.removeChild(host);
                
                            }
                            else{
                                alert("Pogresna sifra!");
                            }

                    })
                } 
                else{
                    p.text().then(data=>
                        {
                            alert(data);
                        })

                }                                                     
            });

    
        }
registracija(host) {


        let ime; let prezime;
        if (host.querySelector(".KorisnikTextBoxIme").value !== "")
            ime = host.querySelector(".KorisnikTextBoxIme").value;
        else {
            alert("Nije uneto ime");
            return;
        }

        if (host.querySelector(".KorisnikTextBoxPrezime").value !== "")
            prezime = host.querySelector(".KorisnikTextBoxPrezime").value;
        else {
            alert("Nije uneto prezime");
            return;
        }
        let username; let sifra;

        if (host.querySelector(".KorisnikTextBoxusername").value !== "")
            username = host.querySelector(".KorisnikTextBoxusername").value;     
        else {
            alert("Nije uneto korisnicko ime");
            return;
        }
        if (host.querySelector(".KorisnikTextBoxsifra").value !== "")
            sifra = host.querySelector(".KorisnikTextBoxsifra").value;
        else {
            alert("Nije uneta sifra");
            return;
        }
                        
        var korisnik; 

        fetch("https://localhost:5001/Korisnik/RegistrujSe/" + this.id +"/"+ ime + "/" + prezime + "/" + username +"/"+ sifra,
        {
            method:"POST"
        }).then(p => {
            if(p.ok){
                    p.json().then(data => {
                    console.log("KREIRAM KORISNIKA");
                    if(sifra.length>=8){
            
                    korisnik=new Korisnik(data.ime,data.prezime,data.username,data.sifra, this);
                    this.korisnik=korisnik;
                    alert("Uspesno ste se registrovali!");
                    var roditelj=host.parentNode;
                    roditelj.removeChild(host);
                    }
                    else{
                        alert("Sifra mora imati minimum 8 karaktera!");
                    }
                    })
                } 
                else{
                    p.text().then(data=>
                        {
                            alert(data);
                        })

                }                                                 
            });
            console.log(this.korisnik);
        }

        vratiRezervacije(host)
        {
            let rezervacijeForma=host.querySelector(".RezervacijeForma");
            if(rezervacijeForma!=null)
            {
                var roditelj=rezervacijeForma.parentNode;
                roditelj.removeChild(rezervacijeForma);
            }


            rezervacijeForma=document.createElement("div");
            host.appendChild(rezervacijeForma);
            rezervacijeForma.className="RezervacijeForma";
            let tabela=this.napraviRezervacijeTabelu(rezervacijeForma);
           

           // let listaTermina=[];
           console.log(this.korisnik.username);
            fetch("https://localhost:5001/Rezervacija/VratiRezervacije/"+this.id+"/"+this.korisnik.username)
            .then(p => {
                if(p.ok){
                    p.json().then(data => {
                        data.forEach(rez =>
                            {
                                //var tr=document.createElement("tr");
                               var rezervacija=new Rezervacija(this,rez.id,rez.rezervisaniTermin.radnik.usluga.naziv,rez.rezervisaniTermin.datum,rez.rezervisaniTermin.radnik.ime +" "+rez.rezervisaniTermin.radnik.prezime,rez.rezervisaniTermin.termin.vremeOd+"-"+rez.rezervisaniTermin.termin.vremeDo);
                               console.log(rezervacija);
                               rezervacija.upisiRezervaciju(tabela);
                               //host.appendChild(tr);
                            });
                        })
                    }
                    else{
                        p.text().then(data=>
                            {
                                alert(data);
                            })
                    }

                    })
            
        }

        napraviRezervacijeTabelu(host)
        {
            var teloTabele=host.querySelector(".RezervacijeForma");
            if(teloTabele!=null)
            {
                var roditelj=telotabele.parentNode;
                roditelj.removeChild(telotabele);
            }

            teloTabele=document.createElement("tbody");
            teloTabele.className="RezervacijeForma";
            host.appendChild(teloTabele);

            let red=document.createElement("tr");
            teloTabele.appendChild(red);

            let h=document.createElement("th");
            h.innerHTML="Usluga";
            red.appendChild(h);

            h=document.createElement("th");
            h.innerHTML="Datum";
            red.appendChild(h);

            h=document.createElement("th");
            h.innerHTML="Radnik";
            red.appendChild(h);

            h=document.createElement("th");
            h.innerHTML="Termin";
            red.appendChild(h);

            h=document.createElement("th");
            h.innerHTML="Otkazivanje";
            red.appendChild(h);

            return teloTabele;

        }

        formaIzmena(host)
        {
            var korisnikForma = host.querySelector(".KorisnikForma");
            if (korisnikForma !== null) {
                var rod = korisnikForma.parentNode;
                rod.removeChild(korisnikForma);
            }
    
            korisnikForma = document.createElement("div");
            korisnikForma.className = "KorisnikForma";
            //this.kont = korisnikForma;
            host.appendChild(korisnikForma);
    
    
            let red = document.createElement("div");
            red.className = "KorisnikRed";

            let labela = document.createElement("label");
            labela.innerHTML = "Novo ime:";
            labela.className = "KorisnikLabela"

            let tb = document.createElement("input");
            tb.className="KorisnikTextBoxIme";
            tb.value=this.korisnik.ime;

            korisnikForma.appendChild(red);
            red.appendChild(labela);
            red.appendChild(tb);
            korisnikForma.appendChild(red);
           

            red = document.createElement("div");
            red.className = "KorisnikRed";

            labela = document.createElement("label");
            labela.innerHTML = "Novo prezime:";
            labela.className = "KorisnikLabela";

            tb = document.createElement("input");
            tb.className="KorisnikTextBoxPrezime";
            tb.value=this.korisnik.prezime;

            red.appendChild(labela);
            red.appendChild(tb);
            korisnikForma.appendChild(red);

            red = document.createElement("div");
            red.className = "KorisnikRed";

            labela = document.createElement("label");
            labela.innerHTML = "Username:";
            labela.className = "KorisnikLabela";

            tb = document.createElement("input");
            tb.readOnly=true;
            tb.className="KorisnikTextBoxusername";
            tb.value=this.korisnik.username;

            red.appendChild(labela);
            red.appendChild(tb);
            korisnikForma.appendChild(red);

            red = document.createElement("div");
            red.className = "KorisnikRed";

            labela = document.createElement("label");
            labela.innerHTML = "Nova sifra:";
            labela.className = "KorisnikLabela";

            tb = document.createElement("input");
            tb.className="KorisnikTextBoxsifra";
            tb.value=this.korisnik.sifra;

            red.appendChild(labela);
            red.appendChild(tb);
            korisnikForma.appendChild(red);
    
            var btnIzmeni = document.createElement("button");
            btnIzmeni.onclick = (ev) =>{

                 this.izmeniKorisnika(korisnikForma);

            }

            btnIzmeni.innerHTML = "Sačuvaj izmene";
            btnIzmeni.className="dugmeIzmeni";
    
            red = document.createElement("div");
            red.className = "KorisnikDugmici";
    
            red.appendChild(btnIzmeni);
            korisnikForma.appendChild(red);

        }

        izmeniKorisnika(host)
        {
            let ime=host.querySelector(".KorisnikTextBoxIme");
            let ime1=ime.value;

            let prezime=host.querySelector(".KorisnikTextBoxPrezime");
            let prezime1=prezime.value;

            let username=host.querySelector(".KorisnikTextBoxusername");
            let username1=username.value;

            let sifra=host.querySelector(".KorisnikTextBoxsifra");
            let sifra1=sifra.value;

            if(sifra1.length<8)
            {
                alert("Sifra mora imati minimalno 8 karaktera!");
                return;
            }

            fetch("https://localhost:5001/Korisnik/IzmeniKorisnika/"+ime1+"/"+prezime1+"/"+username1+"/"+sifra1,
            {
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
            }).then(s=>{
                if(s.ok){
                    s.json().then(data=>{
                        var korisnik=new Korisnik(data.ime,data.prezime,data.username,data.sifra,this);
                        this.korisnik=korisnik;
                        alert("Uspesno ste izmenili podatke!");
                        var roditelj=host.parentNode;
                        roditelj.removeChild(host);
                    })
                }
                else{
                    s.text().then(data=>
                        {
                            alert(data);
                        })
                }
            })

            }


        }





