import { TextField } from "@mui/material";
import * as React from "react";
import Button from '@mui/material/Button';
import {urlbegin,transfer as urltrans,balance as urlbalance,transferin as urltransferin} from './Apicalls.js'

let balancecheck=0;
export default function Transfer() {
  return (
    <div align='center'>
      <h1> Überweisung</h1>
      <div >
        <h2>
      <TextField id="betrag" label="Betrag" variant="outlined" type="number" placeholder="0,00"/> €</h2>
      </div>
      <div>
      <h2>
      <TextField id="kontonr" label="Kontonr" variant="outlined" type="number"/></h2>
      </div>
      <div>
      <h2>
      <TextField id="reason" label="Grund der Überweisung" variant="outlined" /></h2>
      </div>
      <div>
      <Button variant="contained" size="large" onClick={transfer} >Überweisen</Button>
      </div>
      <div>
      <Button variant="contained" size="large" onClick={transferin} >Einzahlung</Button>
      </div>
    </div>
  );
}

const transfer = async () => {

 let kontonr1 = document.getElementById("kontonr").value;
    let betrag1 = document.getElementById("betrag").value;
    let reason1 = document.getElementById("reason").value;

  try {
    const response = await fetch(
      urlbegin+urlbalance,{mode: 'cors',credentials: 'include'}
    );
    if (!response.ok) {
      throw new Error(
        `This is an HTTP error: The status is ${response.status}`
      );
    }
  
    let actualDatabalance = await response.json();
    balancecheck=actualDatabalance[0];
    
    if(balancecheck.sum+parseInt(betrag1)>(-700)){
      try {
        await fetch(urlbegin+urltrans,{
          mode: 'cors',credentials: 'include',
          method: 'POST',
          headers: {'Accept': 'application/json','Content-Type':'application/json'},
            body:  JSON.stringify({ kontonr: ""+kontonr1, betrag: ""+betrag1, reason: ""+reason1 })
        });

      alert("Überweisung erfolgreich")
    } catch(err) {
      alert("Überweisung fehlgeschlagen")
    } 

  }else{
    alert("Nicht genug Guthaben")}
    
  
    
  } catch(err) {
    alert("Überweisung fehlgeschlagen")
    
  } 
}

const transferin = async () => {

  let kontonr1 = document.getElementById("kontonr").value;
     let betrag1 = document.getElementById("betrag").value;
     let reason1 = document.getElementById("reason").value;
 
   try {
     const response = await fetch(
       urlbegin+urlbalance, {mode: 'cors',credentials: 'include'}
     );
     if (!response.ok) {
       throw new Error(
         `This is an HTTP error: The status is ${response.status}`
       );
     }
   
     let actualDatabalance = await response.json();
     balancecheck=actualDatabalance[0];
     
     if(balancecheck.sum+parseInt(betrag1)>(-700)){
       try {
         await fetch(urlbegin+urltransferin,{
          mode: 'cors',credentials: 'include',
           method: 'POST',
           headers: {'Accept': 'application/json','Content-Type':'application/json'},
             body:  JSON.stringify({ kontonr: ""+kontonr1, betrag: ""+betrag1, reason: ""+reason1 })
         });
 
       alert("Überweisung erfolgreich")
     } catch(err) {
       alert("Überweisung fehlgeschlagen")
     } 
 
   }else{
     alert("Nicht genug Guthaben")}
     
   
     
   } catch(err) {
     alert("Überweisung fehlgeschlagen")
     
   } 
 }