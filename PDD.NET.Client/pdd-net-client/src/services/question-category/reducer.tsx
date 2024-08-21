import { createSlice } from "@reduxjs/toolkit";
import {
  IQuestionCategoryResponse,
  IQuestionCategory,
} from "../../types/types";
import {
  createQuestionCategory,
  loadQuestionCategories,
  updateQuestionCategory,
} from "./actions";

interface IQuestionCategoryState {
  questionCategories: IQuestionCategory[];
  questionCategoriesLoading: boolean;
  questionCategoriesError: string | null;

  questionCategoryResponse: IQuestionCategoryResponse | null;

  createQuestionCategoryLoading: boolean;
  createQuestionCategoryError: string | null;

  updateQuestionCategoryLoading: boolean;
  updateQuestionCategoryError: string | null;
}

const initialState: IQuestionCategoryState = {
  questionCategories: [],
  questionCategoriesLoading: false,
  questionCategoriesError: null,

  questionCategoryResponse: null,

  createQuestionCategoryLoading: false,
  createQuestionCategoryError: null,

  updateQuestionCategoryLoading: false,
  updateQuestionCategoryError: null,
};

export const questionCategoriesSlice = createSlice({
  name: "questionCategories",
  initialState,
  reducers: {
    resetQuestionCategoryState: (state) => {
      state.createQuestionCategoryError = null;
      state.updateQuestionCategoryError = null;
      state.questionCategoryResponse = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadQuestionCategories.pending, (state) => {
        state.questionCategoriesLoading = true;
        state.questionCategoriesError = null;
      })
      .addCase(loadQuestionCategories.fulfilled, (state, action) => {
        state.questionCategories = action.payload;
        state.questionCategoriesLoading = false;
      })
      .addCase(loadQuestionCategories.rejected, (state, action) => {
        state.questionCategoriesLoading = false;
        state.questionCategoriesError = action?.error?.message as string;
      })
      .addCase(createQuestionCategory.pending, (state) => {
        state.createQuestionCategoryLoading = true;
        state.createQuestionCategoryError = null;
      })
      .addCase(createQuestionCategory.fulfilled, (state, action) => {
        state.questionCategoryResponse = action.payload;
        state.createQuestionCategoryLoading = false;
      })
      .addCase(createQuestionCategory.rejected, (state, action) => {
        state.createQuestionCategoryLoading = false;
        state.createQuestionCategoryError = action?.error?.message as string;
      })
      .addCase(updateQuestionCategory.pending, (state) => {
        state.updateQuestionCategoryLoading = true;
        state.updateQuestionCategoryError = null;
      })
      .addCase(updateQuestionCategory.fulfilled, (state, action) => {
        state.questionCategoryResponse = action.payload;
        state.updateQuestionCategoryLoading = false;
      })
      .addCase(updateQuestionCategory.rejected, (state, action) => {
        state.updateQuestionCategoryLoading = false;
        state.updateQuestionCategoryError = action?.error?.message as string;
      });
  },
});

export const { resetQuestionCategoryState } = questionCategoriesSlice.actions;
