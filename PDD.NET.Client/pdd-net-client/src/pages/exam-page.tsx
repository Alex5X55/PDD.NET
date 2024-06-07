import React, { useState } from "react";
import { Route, Routes } from "react-router-dom";
import QuestionNumberList from "../components/question-number-list";
import QuestionCard from "../components/question-card";
import Button from "react-bootstrap/Button";
import useQuestionNavigation from "../hooks/use-question-navigation";

const ExamPage: React.FC = () => {
  const [isStart, setIsStart] = useState<boolean>(false);
  const { currentQuestions } = useQuestionNavigation(true);

  const onStartHandleClick = () => {
    setIsStart(true);
  };

  const onFinishHandleClick = () => {
    setIsStart(false);
  };

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Экзамен</h1>
      </header>
      {!isStart ? (
        <>
          <Button
            variant="primary"
            className="mb-3"
            onClick={onStartHandleClick}
          >
            Начать экзамен
          </Button>
          <div>После нажатия на кнопку "Начать экзамен", пойдет таймер.</div>
        </>
      ) : (
        <>
          <Button
            variant="primary"
            className="mb-3"
            onClick={onFinishHandleClick}
          >
            Завершить экзамен
          </Button>
          <QuestionNumberList questions={currentQuestions} />
          <Routes>
            <Route path=":questionId" element={<QuestionCard />} />
          </Routes>
        </>
      )}
    </div>
  );
};

export default ExamPage;
