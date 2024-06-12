import { RootState } from "../store";

export const getSelectedQuestionCategory = (state: RootState) =>
  state.question.currentQuestionCategory;

export const getCurrentQuestions = (state: RootState) =>
  state.question.currentQuestions;

export const getCurrentQuestionNumber = (state: RootState) =>
  state.question.currentQuestionNumber;
