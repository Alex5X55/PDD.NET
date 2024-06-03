import React from "react";
import AppHeader from "../app-header/app-header";
import HomePage from "../../pages/home/home-page";
import { Route, Routes } from "react-router-dom";
import NotFoundPage from "../../pages/not-found/not-found-page";

function App() {
  return (
    <>
      <AppHeader />

      <Routes>
        <Route path="/" element={<HomePage />} />

        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </>
  );
}

export default App;
