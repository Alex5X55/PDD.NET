import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAnswerOption, IQuestion } from "../../types/types";

interface ModalState {
  isShowModal: boolean;
  deletingAnswerOption: IAnswerOption | null;
  deletingQuestion: IQuestion | null;
}

const initialState: ModalState = {
  isShowModal: false,
  deletingAnswerOption: null,
  deletingQuestion: null,
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
} = modalSlice.actions;
