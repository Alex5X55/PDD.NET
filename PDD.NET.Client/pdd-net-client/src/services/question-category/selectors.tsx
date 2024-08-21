import { RootState } from "../store";

export const getQuestionCategoriesLoading = (state: RootState) =>
  state.questionCategories.questionCategoriesLoading;

export const getQuestionCategoriesError = (state: RootState) =>
  state.questionCategories.questionCategoriesError;

export const getQuestionCategories = (state: RootState) =>
  state.questionCategories.questionCategories;

export const getQuestionCategoryResponse = (state: RootState) =>
  state.questionCategories.questionCategoryResponse;

export const createQuestionCategoryLoading = (state: RootState) =>
  state.questionCategories.createQuestionCategoryLoading;

export const createQuestionCategoryError = (state: RootState) =>
  state.questionCategories.createQuestionCategoryError;

export const updateQuestionCategoryLoading = (state: RootState) =>
  state.questionCategories.updateQuestionCategoryLoading;

export const updateQuestionCategoryError = (state: RootState) =>
  state.questionCategories.updateQuestionCategoryError;
