import React from "react";
import AppHeader from "./app-header";
import HomePage from "../pages/home-page";
import { Route, Routes } from "react-router-dom";
import NotFoundPage from "../pages/not-found-page";
import RegisterPage from "../pages/register-page";

function App() {
  return (
    <>
      <AppHeader />

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/register" element={<RegisterPage />} />

        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </>
  );
}

export default App;
