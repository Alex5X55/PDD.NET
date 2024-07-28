import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAnswer } from "../../types/types";

interface AnswerState {
  currentAnswers: IAnswer[];
}

const initialState: AnswerState = {
  currentAnswers: [],
};

export const answerSlice = createSlice({
  name: "answer",
  initialState,
  reducers: {
    addCurrentAnswer: (state, action: PayloadAction<IAnswer>) => {
      state.currentAnswers.push(action.payload);
    },
    resetCurrentAnswers: (state) => {
      state.currentAnswers = [];
    },
  },
});

export const { addCurrentAnswer, resetCurrentAnswers } = answerSlice.actions;
