import { TextField } from "@mui/material";
import * as React from "react";
import Button from '@mui/material/Button';
import {urlbegin,transfer as urltrans,balance as urlbalance} from './Apicalls.js'

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
    </div>
  );
}

const transfer = async () => {

 let kontonr = document.getElementById("kontonr").value;
    let betrag = document.getElementById("betrag").value;
    let reason = document.getElementById("reason").value;

  try {
    const response = await fetch(
      urlbegin+urlbalance+"0"
    );
    if (!response.ok) {
      throw new Error(
        `This is an HTTP error: The status is ${response.status}`
      );
    }
  
    let actualDatabalance = await response.json();
    balancecheck=actualDatabalance[0];
    let check= balancecheck.sum - betrag;
    
    console.log(balancecheck.sum);
    console.log(check);
    console.log(parseInt(betrag));
    if(balancecheck.sum+parseInt(betrag)>(-700)){
      try {
      const response = await fetch(
        urlbegin+urltrans+kontonr+"/"+betrag+"/"+reason
      );
      if (!response.ok) {
        throw new Error(
          `This is an HTTP error: The status is ${response.status}`
        );
      }
      
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