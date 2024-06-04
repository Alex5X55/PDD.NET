import React from "react";
import AppHeader from "./app-header";
import HomePage from "../pages/home-page";
import { Route, Routes } from "react-router-dom";
import NotFoundPage from "../pages/not-found-page";
import RegisterPage from "../pages/register-page";
import AppFooter from "./app-footer";
import Container from "react-bootstrap/Container";
import LoginPage from "../pages/login-page";
import RestorePasswordPage from "../pages/restore-password";
import ResetPasswordPage from "../pages/reset-password";
import QuestionCategoriesPage from "../pages/question-categories-page";
import QuestionCategoryPage from "../pages/question-category-page";
import QuestionCard from "./question-card";
import QuestionLayout from "./question-layout";

function App() {
  return (
    <div className="d-flex flex-column min-vh-100">
      <AppHeader />
      <Container className="flex-grow-1">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/restore-password" element={<RestorePasswordPage />} />
          <Route path="/reset-password" element={<ResetPasswordPage />} />
          <Route
            path="/question-categories"
            element={<QuestionCategoriesPage />}
          />
          <Route
            path="/question-category/:categoryId/*"
            element={<QuestionLayout />}
          />
          <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </Container>
      <AppFooter />
    </div>
  );
}

export default App;
