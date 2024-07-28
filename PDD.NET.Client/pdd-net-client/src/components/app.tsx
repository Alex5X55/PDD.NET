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
import ExamPage from "../pages/exam-page";
import { loadQuestionCategories } from "../services/question-category/actions";
import AdminPanelPage from "../pages/admin-panel-page";
import AdminQuestionsPage from "../pages/admin-questions-page";
import AdminQuestionCategoriesPage from "../pages/admin-question-categories-page";
import AdminUserStatisticsPage from "../pages/admin-user-statistics-page";

function App() {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(loadQuestionCategories());
  }, [dispatch]);

  return (
    <div className="d-flex flex-column min-vh-100">
      <AppHeader />
      <Container className="flex-grow-1">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/admin" element={<AdminPanelPage />} />
          <Route path="/admin/questions" element={<AdminQuestionsPage />} />
          <Route
            path="/admin/question-categories"
            element={<AdminQuestionCategoriesPage />}
          />
          <Route
            path="/admin/user-statistics"
            element={<AdminUserStatisticsPage />}
          />
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
