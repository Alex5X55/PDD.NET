import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import {
  ICreateQuestionCategoryResponse,
  IQuestionCategory,
} from "../../types/types";
import { createQuestionCategory, loadQuestionCategories } from "./actions";

interface IQuestionCategoryState {
  questionCategories: IQuestionCategory[];
  questionCategoriesLoading: boolean;
  questionCategoriesError: string | null;

  newQuestionCategory: ICreateQuestionCategoryResponse | null;
  createQuestionCategoryLoading: boolean;
  createQuestionCategoryError: string | null;
}

const initialState: IQuestionCategoryState = {
  questionCategories: [],
  questionCategoriesLoading: false,
  questionCategoriesError: null,

  newQuestionCategory: null,
  createQuestionCategoryLoading: false,
  createQuestionCategoryError: null,
};

export const questionCategoriesSlice = createSlice({
  name: "questionCategories",
  initialState,
  reducers: {
    resetQuestionCategoryState: (state) => {
      state.createQuestionCategoryError = null;
    },
    pushNewQuestionCategory: (
      state,
      action: PayloadAction<ICreateQuestionCategoryResponse>,
    ) => {
      state.questionCategories.push(action.payload);
      state.newQuestionCategory = null;
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
        state.newQuestionCategory = action.payload;
        state.createQuestionCategoryLoading = false;
      })
      .addCase(createQuestionCategory.rejected, (state, action) => {
        state.createQuestionCategoryLoading = false;
        state.createQuestionCategoryError = action?.error?.message as string;
      });
  },
});

export const { pushNewQuestionCategory, resetQuestionCategoryState } =
  questionCategoriesSlice.actions;
