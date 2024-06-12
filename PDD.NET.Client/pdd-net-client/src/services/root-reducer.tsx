import { combineReducers } from "@reduxjs/toolkit";
import { questionSlice } from "./question/reducer";
import { questionCategoriesSlice } from "./question-category/reducer";

export const rootReducer = combineReducers({
  question: questionSlice.reducer,
  questionCategories: questionCategoriesSlice.reducer,
});
