import { RootState } from "../store";

export const getCurrentAnswers = (state: RootState) =>
  state.answer.currentAnswers;
