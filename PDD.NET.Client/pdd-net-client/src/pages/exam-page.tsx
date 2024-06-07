import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { getCurrentQuestions } from "../services/question/selectors";
import { Route, Routes, useNavigate } from "react-router-dom";
import QuestionNumberList from "../components/question-number-list";
import QuestionCard from "../components/question-card";
import { setExamQuestion } from "../services/question/reducer";

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

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Экзамен</h1>
      </header>
      <QuestionNumberList questions={currentQuestions} />
      <Routes>
        <Route path=":questionId" element={<QuestionCard />} />
      </Routes>
    </div>
  );
};

export default ExamPage;
