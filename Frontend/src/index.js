import { StrictMode } from "react";
import { createRoot } from "react-dom/client";

import Startpage from "./Startpage";
import Header from "./Header";
const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
  <StrictMode>
    <Header />
    <Startpage />
  </StrictMode>
);
