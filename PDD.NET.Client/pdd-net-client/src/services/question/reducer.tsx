import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IQuestion, IQuestionCategory } from "../../types/types";
import { mockData } from "../../data/mock-data";

interface QuestionState {
  currentQuestionCategory: IQuestionCategory | null;
  currentQuestions: IQuestion[];
  currentQuestionNumber: number;
}

const initialState: QuestionState = {
  currentQuestionCategory: null,
  currentQuestions: [],
  currentQuestionNumber: 0,
};

export const questionSlice = createSlice({
  name: "question",
  initialState,
  reducers: {
    setCurrentQuestionCategory: (
      state,
      action: PayloadAction<IQuestionCategory>,
    ) => {
      state.currentQuestionCategory = action.payload;
      state.currentQuestions = mockData.questions.filter(
        (question) => question.categoryId === action.payload?.id,
      );
    },
    setExamQuestion: (state) => {
      // TODO: Сделать запрос с сервера. Пока для тестирования захардкожено.
      state.currentQuestions = mockData.questions;
    },
    setNextQuestion: (state) => {
      const newQuestionNumber: number = state.currentQuestionNumber + 1;
      if (newQuestionNumber > state.currentQuestions?.length - 1) {
        alert("Это был последний вопрос!");
      } else {
        state.currentQuestionNumber = newQuestionNumber;
      }
    },
    setPrevQuestion: (state) => {
      const newQuestionNumber: number = state.currentQuestionNumber - 1;
      if (newQuestionNumber < 0) {
        alert("Это был первый вопрос!");
      } else {
        state.currentQuestionNumber = newQuestionNumber;
      }
    },
    setCurrentQuestionNumber: (state, action: PayloadAction<IQuestion>) => {
      if (state.currentQuestions.length > 0) {
        state.currentQuestionNumber = state.currentQuestions.findIndex(
          (question) => question.id === action.payload.id,
        );
      }
    },
    resetCurrentQuestionNumber: (state) => {
      state.currentQuestionNumber = 0;
    },
  },
});

export const {
  setCurrentQuestionCategory,
  setExamQuestion,
  setNextQuestion,
  setPrevQuestion,
  setCurrentQuestionNumber,
  resetCurrentQuestionNumber,
} = questionSlice.actions;
