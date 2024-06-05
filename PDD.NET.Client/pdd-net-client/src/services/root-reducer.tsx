import { combineReducers } from "@reduxjs/toolkit";
import { questionSlice } from "./question/reducer";

export const rootReducer = combineReducers({
  question: questionSlice.reducer,
});
