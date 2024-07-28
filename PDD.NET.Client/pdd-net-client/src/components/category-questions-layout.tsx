import React from "react";
import { Route, Routes, useNavigate } from "react-router-dom";
import QuestionCard from "./question-card";
import QuestionNumberList from "./question-number-list";
import useQuestionNavigation from "../hooks/use-question-navigation";
import Button from "react-bootstrap/Button";
import Preloader from "./preloader/preloader";
import { useAppSelector } from "../services/hooks";
import {
  getCurrentQuestionsError,
  getCurrentQuestionsLoading,
} from "../services/question/selectors";

const CategoryQuestionsLayout: React.FC = () => {
  const { currentQuestionCategory, currentQuestions } = useQuestionNavigation();
  const isLoading = useAppSelector(getCurrentQuestionsLoading);
  const error = useAppSelector(getCurrentQuestionsError);

  const navigate = useNavigate();

  const onBackCategoriesHandleClick = () => {
    navigate("/question-categories");
  };

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">{currentQuestionCategory?.text}</h1>
      </header>
      <Button
        variant="primary"
        onClick={onBackCategoriesHandleClick}
        className="mb-3"
      >
        Назад к категориям
      </Button>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      {currentQuestions.length > 0 ? (
        <>
          <QuestionNumberList questions={currentQuestions} />
          <Routes>
            <Route path=":questionId" element={<QuestionCard />} />
          </Routes>
        </>
      ) : (
        <div>Вопрос не найден</div>
      )}
    </div>
  );
};

export default CategoryQuestionsLayout;
