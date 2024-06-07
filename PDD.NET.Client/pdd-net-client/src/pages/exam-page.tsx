import React from "react";
import { Route, Routes } from "react-router-dom";
import QuestionNumberList from "../components/question-number-list";
import QuestionCard from "../components/question-card";
import Button from "react-bootstrap/Button";
import useQuestionNavigation from "../hooks/use-question-navigation";

const ExamPage: React.FC = () => {
  const { currentQuestions } = useQuestionNavigation(true);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Экзамен</h1>
      </header>
      <Button variant="primary" className="mb-3">
        Начать экзамен
      </Button>
      <Button variant="primary" className="mb-3">
        Завершить экзамен
      </Button>
      <QuestionNumberList questions={currentQuestions} />
      <Routes>
        <Route path=":questionId" element={<QuestionCard />} />
      </Routes>
    </div>
  );
};

export default ExamPage;
