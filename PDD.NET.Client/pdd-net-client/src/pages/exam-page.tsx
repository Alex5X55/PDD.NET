import React, { useState, useEffect, useRef, useMemo } from "react";
import { Route, Routes } from "react-router-dom";
import QuestionNumberList from "../components/question-number-list";
import QuestionCard from "../components/question-card";
import Button from "react-bootstrap/Button";
import useQuestionNavigation from "../hooks/use-question-navigation";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { resetCurrentAnswers } from "../services/answer/reducer";
import { getCurrentAnswers } from "../services/answer/selectors";
import {
  getCurrentExamQuestionsError,
  getCurrentExamQuestionsLoading,
} from "../services/question/selectors";
import Preloader from "../components/preloader/preloader";
import {
  getCreateExamHistoryError,
  getCreateExamHistoryLoading,
} from "../services/exam-history/selectors";
import { resetExamHistoryState } from "../services/exam-history/reducer";
import { createExamHistory } from "../services/exam-history/actions";
import { getUser } from "../services/auth/selectors";

const ExamPage: React.FC = () => {
  const dispatch = useAppDispatch();

  const { currentQuestions } = useQuestionNavigation(true);

  // Берем первые 20 вопросов
  const initialQuestions = useMemo(
    () => currentQuestions.slice(0, 20),
    [currentQuestions],
  );

  const currentAnswers = useAppSelector(getCurrentAnswers);
  const rightAnswersCount = useMemo(
    () => currentAnswers.filter((item) => item.isRight).length,
    [currentAnswers],
  );
  const wrongAnswersCount = useMemo(
    () => currentAnswers.filter((item) => !item.isRight).length,
    [currentAnswers],
  );

  // Формируем список дополнительных вопросов в зависимости от количества ошибок
  const additionalQuestions = useMemo(() => {
    if (wrongAnswersCount === 0) return [];
    if (wrongAnswersCount === 1) return currentQuestions.slice(20, 25);
    return currentQuestions.slice(20, 30);
  }, [wrongAnswersCount, currentQuestions]);

  const isLoading = useAppSelector(getCurrentExamQuestionsLoading);
  const error = useAppSelector(getCurrentExamQuestionsError);

  const initTimeLeft: number = 1200; // 20 минут = 1200 секунд
  const [isStart, setIsStart] = useState<boolean>(false);
  const [timeLeft, setTimeLeft] = useState<number>(initTimeLeft);
  const hasFinished = useRef(false);
  const [isShowResults, setIsShowResults] = useState<boolean>(false);

  useEffect(() => {
    let timer: NodeJS.Timeout;

    if (isStart && timeLeft >= 0) {
      timer = setInterval(() => {
        setTimeLeft((prevTime) => prevTime - 1);
      }, 1000);
    } else if (timeLeft < 0 && !hasFinished.current) {
      hasFinished.current = true;
      onFinishHandleClick();
    }

    return () => {
      clearInterval(timer);
    };
  }, [isStart, timeLeft]);

  const onStartHandleClick = () => {
    setIsShowResults(false);
    dispatch(resetExamHistoryState());
    dispatch(resetCurrentAnswers());

    setIsStart(true);
    setTimeLeft(initTimeLeft);
    hasFinished.current = false;
  };

  const isCreateLoading = useAppSelector(getCreateExamHistoryLoading);
  const createError = useAppSelector(getCreateExamHistoryError);
  const currentUser = useAppSelector(getUser);

  const isSuccess = useMemo(() => {
    return (
      (wrongAnswersCount === 0 && rightAnswersCount === 20) ||
      (wrongAnswersCount === 1 && rightAnswersCount === 24) ||
      (wrongAnswersCount === 2 && rightAnswersCount === 28)
    );
  }, [wrongAnswersCount, rightAnswersCount]);

  const onFinishHandleClick = () => {
    if (currentUser && currentUser.id) {
      dispatch(
        createExamHistory({ userId: currentUser.id, isSuccess: isSuccess }),
      );
    }
    setIsStart(false);
    setIsShowResults(true);
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
      {isCreateLoading && <Preloader />}
      {createError && <h1 className="display-4 mb-4">Ошибка: {createError}</h1>}
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
          {isShowResults && (
            <>
              <h4 className="display-8 mt-4">Экзамен завершен!</h4>
              <div>Результат: {isSuccess ? "Успех" : "Неудача"}</div>
              <div>Правильных ответов: {rightAnswersCount}</div>
              <div>Неправильных ответов: {wrongAnswersCount}</div>
            </>
          )}
        </>
      ) : (
        <>
          {isLoading && <Preloader />}
          {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
          <div className="d-flex justify-content-between align-items-center mb-3">
            <Button variant="primary" onClick={onFinishHandleClick}>
              Завершить экзамен
            </Button>
            <p
              className="timer fs-2 fw-bold me-4"
              style={{ marginLeft: "auto" }}
            >
              {formatTime(timeLeft)}
            </p>
          </div>
          <QuestionNumberList
            questions={initialQuestions}
            initNumberQuestion={0}
          />
          {wrongAnswersCount > 0 && <div>Дополнительные вопросы:</div>}
          {wrongAnswersCount > 0 && (
            <QuestionNumberList
              questions={additionalQuestions}
              initNumberQuestion={20}
            />
          )}
          <Routes>
            <Route path=":questionId" element={<QuestionCard />} />
          </Routes>
        </>
      )}
    </div>
  );
};

export default ExamPage;
