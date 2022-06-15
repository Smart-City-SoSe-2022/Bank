import { StrictMode } from "react";
import { createRoot } from "react-dom/client";

import Header from "./Apps/Header";
import Auswahl from "./Apps/Auswahl";

const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
  <StrictMode>
    <Header />
    <Auswahl />
  </StrictMode>
);
