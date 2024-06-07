import React, { useState, useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import QuestionNumberList from "../components/question-number-list";
import QuestionCard from "../components/question-card";
import Button from "react-bootstrap/Button";
import useQuestionNavigation from "../hooks/use-question-navigation";

const ExamPage: React.FC = () => {
  const [isStart, setIsStart] = useState<boolean>(false);
  const [timeLeft, setTimeLeft] = useState<number>(1200); // 20 минут в секундах
  const { currentQuestions } = useQuestionNavigation(true);

  useEffect(() => {
    let timer: NodeJS.Timeout;

    if (isStart && timeLeft > 0) {
      timer = setInterval(() => {
        setTimeLeft((prevTime) => prevTime - 1);
      }, 1000);
    } else if (timeLeft === 0) {
      onFinishHandleClick();
    }

    return () => {
      clearInterval(timer);
    };
  }, [isStart, timeLeft]);

  const onStartHandleClick = () => {
    setIsStart(true);
    setTimeLeft(1200);
  };

  const onFinishHandleClick = () => {
    setIsStart(false);
    alert("Экзамен завершен!");
  };

  const formatTime = (seconds: number) => {
    const minutes = Math.floor(seconds / 60);
    const remainingSeconds = seconds % 60;
    return `${minutes}:${remainingSeconds < 10 ? "0" : ""}${remainingSeconds}`;
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
          <div className="d-flex justify-content-between align-items-center mb-3">
            <Button variant="primary" onClick={onFinishHandleClick}>
              Завершить экзамен
            </Button>
            <p className="fs-2 fw-bold me-4">
              <div className="timer" style={{ marginLeft: "auto" }}>
                {formatTime(timeLeft)}
              </div>
            </p>
          </div>
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
