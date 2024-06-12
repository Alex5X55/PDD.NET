import { RootState } from "../store";

export const getQuestionCategoriesLoading = (state: RootState) =>
  state.questionCategories.questionCategoriesLoading;

export const getQuestionCategoriesError = (state: RootState) =>
  state.questionCategories.questionCategoriesError;

export const getQuestionCategories = (state: RootState) =>
  state.questionCategories.questionCategories;
