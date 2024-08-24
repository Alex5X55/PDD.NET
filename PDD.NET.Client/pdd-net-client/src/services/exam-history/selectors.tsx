import { RootState } from "../store";

export const getCreateExamHistoryLoading = (state: RootState) =>
  state.examHistory.createExamHistoryLoading;

export const getCreateExamHistoryError = (state: RootState) =>
  state.examHistory.createExamHistoryError;
