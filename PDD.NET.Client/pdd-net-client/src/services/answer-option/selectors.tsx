import { RootState } from "../store";

export const getAnswerOptionResponse = (state: RootState) =>
  state.answerOptions.answerOptionResponse;

export const createAnswerOptionLoading = (state: RootState) =>
  state.answerOptions.createAnswerOptionLoading;

export const createAnswerOptionError = (state: RootState) =>
  state.answerOptions.createAnswerOptionError;

export const updateAnswerOptionLoading = (state: RootState) =>
  state.answerOptions.updateAnswerOptionLoading;

export const updateAnswerOptionError = (state: RootState) =>
  state.answerOptions.updateAnswerOptionError;
