import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IQuestion, IQuestionCategory } from "../../types/types";
import { mockData } from "../../data/mock-data";

interface QuestionState {
  questionCategories: IQuestionCategory[];
  selectedQuestionCategory: IQuestionCategory | null;
  currentQuestions: IQuestion[];
}

const initialState: QuestionState = {
  questionCategories: [],
  selectedQuestionCategory: null,
  currentQuestions: [],
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
  },
});

export const { setQuestionCategory, setQuestionCategories } =
  questionSlice.actions;
