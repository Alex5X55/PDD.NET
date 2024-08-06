import { combineReducers } from "@reduxjs/toolkit";
import { questionSlice } from "./question/reducer";
import { questionCategoriesSlice } from "./question-category/reducer";
import { answerSlice } from "./answer/reducer";
import { modalSlice } from "./modal/reducer";

export const rootReducer = combineReducers({
  question: questionSlice.reducer,
  questionCategories: questionCategoriesSlice.reducer,
  answer: answerSlice.reducer,
  modal: modalSlice.reducer,
});
