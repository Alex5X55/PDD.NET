import { RootState } from "../store";

export const getSelectedQuestionCategory = (state: RootState) =>
  state.question.currentQuestionCategory;

export const getCurrentQuestionsLoading = (state: RootState) =>
  state.question.currentQuestionsLoading;

export const getCurrentQuestionsError = (state: RootState) =>
  state.question.currentQuestionsError;

export const getCurrentQuestions = (state: RootState) =>
  state.question.currentQuestions;

export const getCurrentQuestionNumber = (state: RootState) =>
  state.question.currentQuestionNumber;
