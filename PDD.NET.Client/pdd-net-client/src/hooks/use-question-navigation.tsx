import { useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import {
  getCurrentQuestionNumber,
  getCurrentQuestions,
  getQuestionCategories,
  getSelectedQuestionCategory,
} from "../services/question/selectors";
import { IQuestionCategory } from "../types/types";
import {
  setCurrentQuestionCategory,
  setExamQuestion,
} from "../services/question/reducer";

const useQuestionNavigation = (isExam: boolean = false) => {
  const dispatch = useAppDispatch();
  const { categoryId } = useParams<{ categoryId: string }>();
  const navigate = useNavigate();

  const questionCategories = useAppSelector(getQuestionCategories);
  const currentQuestionCategory = useAppSelector(getSelectedQuestionCategory);
  const currentQuestions = useAppSelector(getCurrentQuestions);
  const currentQuestionNumber = useAppSelector(getCurrentQuestionNumber);

  useEffect(() => {
    if (isExam) {
      dispatch(setExamQuestion());
    } else {
      const categoryIdNumber = parseInt(categoryId || "", 10);
      if (categoryIdNumber && questionCategories) {
        const category = questionCategories.find(
          (item: IQuestionCategory) => item.id === categoryIdNumber,
        );
        if (category) {
          dispatch(setCurrentQuestionCategory(category));
        }
      }
    }
  }, [categoryId, questionCategories, dispatch, isExam]);

  useEffect(() => {
    if (currentQuestions.length > 0 && currentQuestionNumber >= 0) {
      navigate(`${currentQuestions[currentQuestionNumber].id}`);
    }
  }, [currentQuestionNumber, currentQuestions]);

  return {
    currentQuestionCategory,
    currentQuestions,
  };
};

export default useQuestionNavigation;
