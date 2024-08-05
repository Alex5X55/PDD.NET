import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IQuestion, IQuestionCategory } from "../../types/types";
import {
  loadAllQuestions,
  loadExamQuestions,
  loadQuestionsByCategory,
} from "./actions";

interface QuestionState {
  currentQuestionCategory: IQuestionCategory | null;
  currentQuestionNumber: number;

  currentQuestions: IQuestion[];

  currentQuestionsLoading: boolean;
  currentQuestionsError: string | null;

  currentExamQuestionsLoading: boolean;
  currentExamQuestionsError: string | null;

  allQuestions: IQuestion[];
  allQuestionsLoading: boolean;
  allQuestionsError: string | null;
}

const initialState: QuestionState = {
  currentQuestionCategory: null,
  currentQuestionNumber: 0,

  currentQuestions: [],

  currentQuestionsLoading: false,
  currentQuestionsError: null,

  currentExamQuestionsLoading: false,
  currentExamQuestionsError: null,

  allQuestions: [],
  allQuestionsLoading: false,
  allQuestionsError: null,
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
  extraReducers: (builder) => {
    builder
      .addCase(loadQuestionsByCategory.pending, (state) => {
        state.currentQuestionsLoading = true;
        state.currentQuestionsError = null;
      })
      .addCase(loadQuestionsByCategory.fulfilled, (state, action) => {
        state.currentQuestions = action.payload;
        state.currentQuestionsLoading = false;
      })
      .addCase(loadQuestionsByCategory.rejected, (state, action) => {
        state.currentQuestionsLoading = false;
        state.currentQuestionsError = action?.error?.message as string;
      })
      .addCase(loadExamQuestions.pending, (state) => {
        state.currentExamQuestionsLoading = true;
        state.currentExamQuestionsError = null;
      })
      .addCase(loadExamQuestions.fulfilled, (state, action) => {
        state.currentQuestions = action.payload;
        state.currentExamQuestionsLoading = false;
      })
      .addCase(loadExamQuestions.rejected, (state, action) => {
        state.currentExamQuestionsLoading = false;
        state.currentExamQuestionsError = action?.error?.message as string;
      })
      .addCase(loadAllQuestions.pending, (state) => {
        state.allQuestionsLoading = true;
        state.allQuestionsError = null;
      })
      .addCase(loadAllQuestions.fulfilled, (state, action) => {
        state.allQuestions = action.payload;
        state.allQuestionsLoading = false;
      })
      .addCase(loadAllQuestions.rejected, (state, action) => {
        state.allQuestionsLoading = false;
        state.allQuestionsError = action?.error?.message as string;
      });
  },
});

export const {
  setCurrentQuestionCategory,
  setNextQuestion,
  setPrevQuestion,
  setCurrentQuestionNumber,
  resetCurrentQuestionNumber,
} = questionSlice.actions;
