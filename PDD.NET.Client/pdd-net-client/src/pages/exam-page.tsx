import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import {
  getCurrentQuestionNumber,
  getCurrentQuestions,
} from "../services/question/selectors";
import { Route, Routes, useNavigate } from "react-router-dom";
import QuestionNumberList from "../components/question-number-list";
import QuestionCard from "../components/question-card";
import { setExamQuestion } from "../services/question/reducer";
import Button from "react-bootstrap/Button";

const ExamPage: React.FC = () => {
  const dispatch = useAppDispatch();
  const currentQuestions = useAppSelector(getCurrentQuestions);

  useEffect(() => {
    dispatch(setExamQuestion());
  }, [dispatch]);

  const navigate = useNavigate();

  useEffect(() => {
    if (currentQuestions.length > 0) {
      navigate(`${currentQuestions[0].id}`);
    }
  }, [currentQuestions]);

  const currentQuestionNumber = useAppSelector(getCurrentQuestionNumber);

  useEffect(() => {
    if (currentQuestions.length > 0 && currentQuestionNumber >= 0) {
      navigate(`${currentQuestions[currentQuestionNumber].id}`);
    }
  }, [currentQuestionNumber, currentQuestions]);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Экзамен</h1>
      </header>
      <Button variant="primary">Начать экзамен</Button>
      <QuestionNumberList questions={currentQuestions} />
      <Routes>
        <Route path=":questionId" element={<QuestionCard />} />
      </Routes>
    </div>
  );
};

export default ExamPage;
