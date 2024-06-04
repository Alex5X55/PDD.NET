import React, { useEffect } from "react";
import { Route, Routes, useNavigate, useParams } from "react-router-dom";
import QuestionCard from "./question-card";
import QuestionNumberList from "./question-number-list";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import {
  getCurrentQuestions,
  getQuestionCategories,
  getSelectedQuestionCategory,
} from "../services/question/selectors";
import { IQuestionCategory } from "../types/types";
import { setQuestionCategory } from "../services/question/reducer";
const CategoryQuestionsLayout: React.FC = () => {
  const dispatch = useAppDispatch();
  const { categoryId } = useParams<{ categoryId: string }>();

  const questionCategories = useAppSelector(getQuestionCategories);
  const currentQuestionCategory = useAppSelector(getSelectedQuestionCategory);
  const currentQuestions = useAppSelector(getCurrentQuestions);

  useEffect(() => {
    const categoryIdNumber = parseInt(categoryId || "", 10);
    if (categoryIdNumber && questionCategories) {
      const category = questionCategories.find(
        (item: IQuestionCategory) => item.id === categoryIdNumber,
      );
      if (category) {
        dispatch(setQuestionCategory(category));
      }
    }
  }, [categoryId, dispatch, questionCategories]);

  const navigate = useNavigate();

  useEffect(() => {
    if (currentQuestions.length > 0) {
      navigate(`${currentQuestions[0].id}`);
    }
  }, [currentQuestions]);

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
