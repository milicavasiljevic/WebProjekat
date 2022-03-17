import { Salon } from "./Salon.js";

export class Div
{
    constructor(salon,indRadnik, indTermin, korisnik)
    {
        this.salon=salon;
        this.indRadnik=indRadnik;
        this.indTermin=indTermin;
        this.korisnikIme=korisnik;
        this.kontejner=null;
          
    }
    crtajDivSlobodan(tabela,host,zakaziDiv)
    {
        var div=document.createElement("div");
        div.className="slobodanTermin";
        this.kontejner=div;
        host.appendChild(div);
        div.setAttribute("data-indeksTermina",this.indTermin);
        div.setAttribute("data-indeksRadnika",this.indRadnik);
        

        div.ondblclick=(ev)=>{
            div.style.backgroundColor="#90EE90";
            div.classList.add("Selektovan");
           
           this.dugmeRezervisi(tabela,zakaziDiv,this.kontejner);
        }


    }

    crtajDivZauzet(host)
    {
        var div=document.createElement("div");
        div.className="zauzetTermin";
        this.kontejner=div;
        host.appendChild(div);
        div.setAttribute("data-indeksTermina",this.indTermin);
        div.setAttribute("data-indeksRadnika",this.indRadnik);
        
    
        div.ondblclick=(ev)=>{
            alert("Termin je zauzet!");
        }

    }
    dugmeRezervisi(tabela,zakaziDiv, div)
        {
            var dugme = zakaziDiv.querySelector(".dugmeZakazi");
            if (dugme !== null) {
            var roditelj = dugme.parentNode;
            roditelj.removeChild(dugme);
        }
            dugme=document.createElement("button");
            dugme.innerHTML="Zakaži";
            dugme.className="dugmeZakazi";
            zakaziDiv.appendChild(dugme);
            //tabela.appendChild(dugmeDiv);
            div.onclick=(ev)=>{
                div.style.backgroundColor="#008000";
                div.classList.remove("Selektovan");
                var sel=tabela.querySelector(".Selektovan");
                if(sel==null)
                {
                    var rodit = dugme.parentNode;
                    rodit.removeChild(dugme);
                }
                return;
            }

            dugme.onclick=(ev)=>this.zakaziTermin(tabela,zakaziDiv);
        }
        zakaziTermin(tabela,zakaziDiv)
        {
            var sel=tabela.querySelectorAll(".Selektovan");
            console.log(sel);
            if(sel==null)
            {
                alert("Odaberite termin!");
            }
            var rod=tabela.parentNode;
            var dat=rod.querySelector(".comboBox3");
            let datum=dat.options[dat.selectedIndex].innerText;

           // console.log(t);
            //console.log(r);
            sel.forEach(element => {

                let t=element.getAttribute("data-indeksTermina");
                let r=element.getAttribute("data-indeksRadnika");
                console.log(this.korisnikIme);
                console.log(t);
                console.log(r);

                fetch("https://localhost:5001/Rezervacija/DodajRezervaciju/" + this.salon.id +"/"+ t + "/" + datum + "/" + r +"/"+ this.korisnikIme,
                {
                    method:"POST"
                    
                }).then(p => {
                    if(p.ok){
                            p.text().then(data => {
                            var rezervacija=tabela.parentNode;
                            this.obrisiTabelu(tabela);
                            var rod=zakaziDiv.parentNode;
                            rod.removeChild(zakaziDiv);
                
                            this.salon.crtajTermine(rezervacija);

                            console.log("DODAJEM REZERVACIJU");
                            alert("Uspesno ste izvrsili zakazivanje!");
                            })
                        }                                                     
                    });          
                
            });
           /* sel.forEach(el=>
                {
                    el.classList.remove(".Selektovan");
                    el.classList.remove(".slobodanTermin");
                    el.className="zauzetTermin";
                })*/

        }
        
        obrisiTabelu(tabela)
        {
            if(tabela!=null)
            {
            var roditelj=tabela.parentNode;
            roditelj.removeChild(tabela);
            }
        }

}