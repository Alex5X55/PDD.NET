import { RootState } from "../store";

export const getQuestionCategories = (state: RootState) =>
  state.questionCategories.questionCategories;
