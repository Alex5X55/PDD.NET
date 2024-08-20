import { RootState } from "../store";

export const getSelectedQuestionCategory = (state: RootState) =>
  state.question.currentQuestionCategory;

export const getCurrentQuestionNumber = (state: RootState) =>
  state.question.currentQuestionNumber;

export const getCurrentQuestions = (state: RootState) =>
  state.question.currentQuestions;

export const getCurrentQuestionsLoading = (state: RootState) =>
  state.question.currentQuestionsLoading;

export const getCurrentQuestionsError = (state: RootState) =>
  state.question.currentQuestionsError;

export const getCurrentExamQuestionsLoading = (state: RootState) =>
  state.question.currentExamQuestionsLoading;

export const getCurrentExamQuestionsError = (state: RootState) =>
  state.question.currentExamQuestionsError;

export const getAllQuestions = (state: RootState) =>
  state.question.allQuestions;

export const getAllQuestionsLoading = (state: RootState) =>
  state.question.allQuestionsLoading;

export const getAllQuestionsError = (state: RootState) =>
  state.question.allQuestionsError;

export const createQuestionLoading = (state: RootState) =>
  state.question.createQuestionLoading;

export const createQuestionError = (state: RootState) =>
  state.question.createQuestionError;

export const getNewQuestion = (state: RootState) => state.question.newQuestion;
