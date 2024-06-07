import React from "react";
import { Route, Routes } from "react-router-dom";
import QuestionCard from "./question-card";
import QuestionNumberList from "./question-number-list";
import useQuestionNavigation from "../hooks/use-question-navigation";

const CategoryQuestionsLayout: React.FC = () => {
  const { currentQuestionCategory, currentQuestions } = useQuestionNavigation();

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">{currentQuestionCategory?.text}</h1>
      </header>
      <QuestionNumberList questions={currentQuestions} />
      <Routes>
        <Route path=":questionId" element={<QuestionCard />} />
      </Routes>
    </div>
  );
};

export default CategoryQuestionsLayout;
