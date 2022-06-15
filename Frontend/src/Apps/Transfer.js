import { TextField } from "@mui/material";
import * as React from "react";
import Button from '@mui/material/Button';
export default function Transfer() {
  return (
    <div>
      <h1> Überweisung</h1>
      <div>
      <TextField id="outlined-basic" label="Betrag" variant="outlined" />
      </div>
      <div>
      <TextField id="outlined-basic" label="Kontonr" variant="outlined" />
      </div>
      <div>
      <TextField id="outlined-basic" label="Grund der Überweisung" variant="outlined" />
      </div>
      <div>
      <Button variant="contained" size="large" onClick={transfer}>Überweisen</Button>
      </div>
    </div>
  );
}

function transfer(){
  alert('clicked');
}
