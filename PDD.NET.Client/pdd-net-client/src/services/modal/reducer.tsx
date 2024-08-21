import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAnswerOption, IQuestion, IQuestionCategory } from "../../types/types";

interface ModalState {
  isShowModal: boolean;
  deletingAnswerOption: IAnswerOption | null;
  deletingQuestion: IQuestion | null;
  deletingQuestionCategory: IQuestionCategory | null;
}

const initialState: ModalState = {
  isShowModal: false,
  deletingAnswerOption: null,
  deletingQuestion: null,
  deletingQuestionCategory: null,
};

export const modalSlice = createSlice({
  name: "modal",
  initialState,
  reducers: {
    setIsShowModal: (state, action: PayloadAction<boolean>) => {
      state.isShowModal = action.payload;
    },
    setDeletingAnswer: (state, action: PayloadAction<IAnswerOption>) => {
      state.deletingAnswerOption = action.payload;
    },
    setDeletingQuestion: (state, action: PayloadAction<IQuestion>) => {
      state.deletingQuestion = action.payload;
    },
    setDeletingQuestionCategory: (
      state,
      action: PayloadAction<IQuestionCategory>,
    ) => {
      state.deletingQuestionCategory = action.payload;
    },
    resetDeletingItems: (state) => {
      state.deletingQuestion = null;
      state.deletingAnswerOption = null;
    },
  },
});

export const {
  setIsShowModal,
  setDeletingAnswer,
  setDeletingQuestion,
  resetDeletingItems,
  setDeletingQuestionCategory,
} = modalSlice.actions;
