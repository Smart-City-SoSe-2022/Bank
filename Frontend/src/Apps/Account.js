import * as React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";



export default function CheckboxList() {
  var kontostand=200
  return (
<div>
    <h1> Kontostand </h1>
    <h2> Ihr Kontostand beträgt : {kontostand} €</h2>
    <List sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}>
      {[0, 1, 2, 3].map((value) => {
        const labelId = `checkbox-list-label-${value}`;
        return (
          <div>
            <ListItem key={value} disablePadding>
              <ListItemText id={labelId} primary={`Betrag  ${value + 1}`} />
              <ListItemText id={labelId} primary={`Username  ${value + 1}`}/>
              <ListItemText id={labelId} primary={`Kontonr  ${value + 1}`}/>
              <ListItemText id={labelId} primary={`Datum ${value + 1}`} />
            </ListItem>
          </div>
        );
      })}
    </List></div>
  );
}
