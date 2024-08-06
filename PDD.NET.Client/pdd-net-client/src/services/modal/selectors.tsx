import { RootState } from "../store";

export const getIsShowModal = (state: RootState) => state.modal.isShowModal;

export const getDeletingAnswer = (state: RootState) =>
  state.modal.deletingAnswer;

export const getDeletingQuestion = (state: RootState) =>
  state.modal.deletingQuestion;
