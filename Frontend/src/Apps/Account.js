import * as React from "react";
import { DataGrid } from '@mui/x-data-grid';
import {balance as urlbalance,urlbegin,debit as urldebit} from './Apicalls.js'
import { useState, useEffect } from "react";
import Cookies from 'universal-cookie';

const columns = [
  { field: 'bankbalance', headerName: 'Betrag', width: 130 },
  { field: 'date', headerName: 'Datum', width: 130 },
  {
    field: 'reason',
    headerName: 'Grund',
    sortable: false,
    width: 90,
  },
  {
    field: 'fromuser',
    headerName: 'Gesendet von',
    description: 'This column has a value getter and is not sortable.',
    sortable: false,
    width: 160,
  },
];

let rows = [
  
  {id: 0,debitid:0,date:"23.06.2022",bankbalance:-300.00,reason:"cool",customerid:0,fromuser:"null"}
 
];



const cookies = new Cookies();


export default function Account() {
  const [balance, setBalance] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

 useEffect(() => {
  const getData1 = async () => {
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

      const response2 = await fetch(
        urlbegin+urldebit
      );
      if (!response2.ok) {
        throw new Error(
          `This is an HTTP error: The status is ${response2.status}`
        );
      }
      let actualData = await response2.json();
      if(actualData){
        
      }
      setBalance(actualDatabalance);
      rows=actualData;
      generaterow()
      setError(null);
    } catch(err) {
      setError(err.message);
      setBalance(null);
    } finally {
      setLoading(false);
    }  
  }
  getData1()
  
  
}, [])
 
   
  return (
    
    <div className="App" align='center'>
    {loading && <div>A moment please...</div>}
    {error && (
      <div>{`There is a problem fetching the post data - ${error}`}</div>
    )}
    {balance &&
        balance.map(({ sum }) => (
          <div>
          <h1> Kontostand </h1>
           <h2> Ihr Kontostand beträgt : {sum} €</h2>
            <div style={{ height: 400, width: '100%' }}>
      <DataGrid
        rows={rows}
        columns={columns}
        pageSize={5}
        rowsPerPageOptions={[5]}
      />
      </div>
    </div>
          
        ))}
    </div>
  );
}

function generaterow(){
for(let i=0;i<rows.length;i++){
  rows[i].id=i;
  rows[i].bankbalance+="€";
}

rows.reverse();

}

