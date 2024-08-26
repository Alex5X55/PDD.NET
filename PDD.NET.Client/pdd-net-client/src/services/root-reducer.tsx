import { combineReducers } from "@reduxjs/toolkit";
import { questionSlice } from "./question/reducer";
import { questionCategoriesSlice } from "./question-category/reducer";
import { answerSlice } from "./answer/reducer";
import { modalSlice } from "./modal/reducer";
import { answerOptionsSlice } from "./answer-option/reducer";
import { examHistorySlice } from "./exam-history/reducer";
import { authSlice } from "./auth/reducer";
import { analyticsDataSlice } from "./analytics/reducer";

export const rootReducer = combineReducers({
  questionCategories: questionCategoriesSlice.reducer,
  question: questionSlice.reducer,
  answerOptions: answerOptionsSlice.reducer,
  answer: answerSlice.reducer,
  modal: modalSlice.reducer,
  examHistory: examHistorySlice.reducer,
  auth: authSlice.reducer,
  analytics: analyticsDataSlice.reducer,
});
