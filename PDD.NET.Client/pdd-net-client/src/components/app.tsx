import React from "react";
import AppHeader from "./app-header";
import HomePage from "../pages/home-page";
import { Route, Routes } from "react-router-dom";
import NotFoundPage from "../pages/not-found-page";
import RegisterPage from "../pages/register-page";
import AppFooter from "./app-footer";
import Container from "react-bootstrap/Container";

function App() {
  return (
    <div className="d-flex flex-column min-vh-100">
      <AppHeader />
      <Container className="flex-grow-1">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />

          <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </Container>
      <AppFooter />
    </div>
  );
}

export default App;
