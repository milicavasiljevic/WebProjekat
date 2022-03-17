import { Salon } from "./Salon.js";
import { Termin } from "./Termin.js";
import {Usluga} from "./Usluga.js";

let listaSalona = [];



fetch("https://localhost:5001/Salon/PreuzmiSalone")
.then(p => {
        p.json().then(data => {
            data.forEach(salon =>
                 {

                    //var rez = await fetch("...");
                    //var data = await rez.json();
                    fetch("https://localhost:5001/Usluga/VratiUsluge/"+ salon.id)
                    .then(p => {
                    p.json().then(data => {
                        console.log(data);
                        let listaUsluga=[];
                        data.forEach((element, index) => {
    
                            var usl=new Usluga(element.usluga.id, element.usluga.naziv, element.cena);
                            //console.log(usl);
                            listaUsluga.push(usl);
                            //pom[index]=usl;
                            
                         });
                         let listaDatuma=[];
                         let listaDat=[];

                        fetch("https://localhost:5001/Termin/PreuzmiDatume")
                         .then(p => {
                         p.json().then(data => {
                             console.log("ovde");
                             data.forEach(datum =>
                                  {
                                     var dat=datum.datum;
                                     listaDatuma.push(dat);

                                  });
                             let nesto=listaDatuma[28];
                             console.log(nesto);
                             let i=0; 
                             //console.log(listaDatuma);
                             listaDatuma.forEach(el => {
                                 console.log(el);
                                 if((listaDat.find(x=>x===el)==undefined))
                                 {
                                     listaDat[i]=el;
                                     i++;
                                 }
                                 
                             });
                             let listaTermina=[];
                             fetch("https://localhost:5001/Termin/PreuzmiTermine")
                             .then(p => {
                                     p.json().then(data => {
                                         data.forEach(termin =>
                                             {
                                                 var ter=new Termin(termin.id, termin.vremeOd, termin.vremeDo);
                                                 listaTermina.push(ter);
                                             });
                                         })
                                        //
                                     })
                                var pozadina=document.createElement("div");
                                pozadina.className="pozadina1";
                                document.body.appendChild(pozadina);       
                             let noviSalon = new Salon(salon.id, salon.naziv, listaUsluga,listaDat, listaTermina);
                             listaSalona.push(noviSalon);
                             noviSalon.crtajSalon(pozadina);
                             console.log(listaDat);  
                              

                        

                 
                             })
                         });
                         console.log(listaDat); 
                 
                        })
                    })
                })
            });
           
        })

