import React, { useEffect } from "react";
import AppHeader from "./app-header";
import HomePage from "../pages/home-page";
import { Route, Routes } from "react-router-dom";
import NotFoundPage from "../pages/not-found-page";
import RegisterPage from "../pages/register-page";
import AppFooter from "./app-footer";
import Container from "react-bootstrap/Container";
import LoginPage from "../pages/login-page";
import RestorePasswordPage from "../pages/restore-password-page";
import ResetPasswordPage from "../pages/reset-password-page";
import QuestionCategoriesPage from "../pages/question-categories-page";
import CategoryQuestionsLayout from "./category-questions-layout";
import { useAppDispatch } from "../services/hooks";
import { setQuestionCategories } from "../services/question/reducer";
import ExamPage from "../pages/exam-page";

function App() {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(setQuestionCategories());
  }, [dispatch]);

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
            element={<CategoryQuestionsLayout />}
          />
          <Route path="/exam/*" element={<ExamPage />} />

          <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </Container>
      <AppFooter />
    </div>
  );
}

export default App;
