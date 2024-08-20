import { RootState } from "../store";

export const createAnswerOptionLoading = (state: RootState) =>
  state.answerOptions.createAnswerOptionLoading;

export const createAnswerOptionError = (state: RootState) =>
  state.answerOptions.createAnswerOptionError;

export const getNewAnswerOption = (state: RootState) =>
  state.answerOptions.newAnswerOption;
