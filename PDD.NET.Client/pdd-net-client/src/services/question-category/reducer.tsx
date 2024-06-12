import { createSlice } from "@reduxjs/toolkit";
import { IQuestionCategory } from "../../types/types";
import { loadQuestionCategories } from "./actions";

interface IQuestionCategoryState {
  questionCategories: IQuestionCategory[];
  questionCategoriesLoading: boolean;
  questionCategoriesError: string | null;
}

const initialState: IQuestionCategoryState = {
  questionCategories: [],
  questionCategoriesLoading: false,
  questionCategoriesError: null,
};

export const questionCategoriesSlice = createSlice({
  name: "questionCategories",
  initialState,
  reducers: {},
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
      });
  },
});
