import { RootState } from "../store";

export const getIsShowModal = (state: RootState) => state.modal.isShowModal;

export const getDeletingAnswerOption = (state: RootState) =>
  state.modal.deletingAnswerOption;

export const getDeletingQuestion = (state: RootState) =>
  state.modal.deletingQuestion;
