import * as React from "react";

export default function Header() {
  return (
    <div>
      <img src={require('./Bank.jpg')} width={100} height={100} alt='Large Pizza' />
      <img src={require('./Bank2.jpg')} width={"85%"} height={100} alt='Large Pizza' />
    </div>
  );
}
