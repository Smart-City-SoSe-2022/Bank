import "./styles.css";
import ReactPlayer from "react-player";
import { styled } from "@mui/material/styles";
import Paper from "@mui/material/Paper";
import { Button } from "@mui/material";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary
}));

export default function Startpage() {
  return (
    <div className="App">
      <h1>Projektmanagmentseite </h1>
      <h1>Willkommen </h1>
      <h2>Diese seite Dient dem Managment deiner Projekte</h2>
      <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={3}>
          <Grid item xs></Grid>
          <Grid item xs={6}>
            <Item>
              <ReactPlayer
                url={"https://youtu.be/ucZl6vQ_8Uo"}
                width="100%"
                height="100%"
                controls={true}
              />
            </Item>
          </Grid>
          <Grid item xs></Grid>
        </Grid>
      </Box>
      <Button variant="contained" disableElevation>
        Test
      </Button>
      <div>
        <Button variant="contained" disableElevation>
          Test
        </Button>
      </div>
    </div>
  );
}
