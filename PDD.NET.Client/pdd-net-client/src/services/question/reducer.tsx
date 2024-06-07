import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IQuestion, IQuestionCategory } from "../../types/types";
import { mockData } from "../../data/mock-data";

interface QuestionState {
  questionCategories: IQuestionCategory[];
  selectedQuestionCategory: IQuestionCategory | null;
  currentQuestions: IQuestion[];
  currentQuestionNumber: number;
}

const initialState: QuestionState = {
  questionCategories: [],
  selectedQuestionCategory: null,
  currentQuestions: [],
  currentQuestionNumber: 0,
};

export const questionSlice = createSlice({
  name: "question",
  initialState,
  reducers: {
    setQuestionCategories: (state) => {
      // TODO: Сделать запрос с сервера. Пока для тестирования захардкожено.
      state.questionCategories = mockData.categories;
    },
    setQuestionCategory: (state, action: PayloadAction<IQuestionCategory>) => {
      state.selectedQuestionCategory = action.payload;
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
  },
});

export const {
  setQuestionCategory,
  setQuestionCategories,
  setExamQuestion,
  setNextQuestion,
  setPrevQuestion,
} = questionSlice.actions;
