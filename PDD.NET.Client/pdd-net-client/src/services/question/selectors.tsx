import { RootState } from "../store";

export const getSelectedQuestionCategory = (state: RootState) =>
  state.question.selectedQuestionCategory;

export const getQuestionCategories = (state: RootState) =>
  state.question.questionCategories;

export const getCurrentQuestions = (state: RootState) =>
  state.question.currentQuestions;

export const getCurrentQuestionNumber = (state: RootState) =>
  state.question.currentQuestionNumber;
