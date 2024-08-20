import { RootState } from "../store";

export const getQuestionCategoriesLoading = (state: RootState) =>
  state.questionCategories.questionCategoriesLoading;

export const getQuestionCategoriesError = (state: RootState) =>
  state.questionCategories.questionCategoriesError;

export const getQuestionCategories = (state: RootState) =>
  state.questionCategories.questionCategories;

export const createQuestionCategoryLoading = (state: RootState) =>
  state.questionCategories.createQuestionCategoryLoading;

export const createQuestionCategoryError = (state: RootState) =>
  state.questionCategories.createQuestionCategoryError;

export const getNewQuestionCategory = (state: RootState) =>
  state.questionCategories.newQuestionCategory;
