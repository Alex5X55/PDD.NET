import { IQuestionCategory } from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { getQuestionCategories } from "../../utils/question-categories-api";

export const loadQuestionCategories = createAsyncThunk<IQuestionCategory[]>(
  "questions/loadQuestionCategories",
  async () => {
    return await getQuestionCategories();
  },
);
