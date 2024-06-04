import React from "react";
import { Route, Routes, useParams } from "react-router-dom";
import QuestionCard from "./question-card";
import { mockData } from "../data/mock-data";
import QuestionNumberList from "./question-number-list";

const QuestionLayout: React.FC = () => {
  const { categoryId } = useParams<{ categoryId: string }>();
  const questions = mockData.questions.filter(
    (question) => question.categoryId === parseInt(categoryId || "", 10),
  );

  return (
    <div className="container">
      <QuestionNumberList questions={questions} />
      <Routes>
        <Route path="/question/questionId" element={<QuestionCard />} />
      </Routes>
    </div>
  );
};

export default QuestionLayout;
