import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IAnswerOption, IQuestion } from "../../types/types";

interface ModalState {
  isShowModal: boolean;
  deletingAnswer: IAnswerOption | null;
  deletingQuestion: IQuestion | null;
}

const initialState: ModalState = {
  isShowModal: false,
  deletingAnswer: null,
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
      state.deletingAnswer = action.payload;
    },
    setDeletingQuestion: (state, action: PayloadAction<IQuestion>) => {
      state.deletingQuestion = action.payload;
    },
  },
});

export const { setIsShowModal, setDeletingAnswer, setDeletingQuestion } =
  modalSlice.actions;
