import { IQuestionCategory } from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { getQuestionCategories } from "../../utils/question-categories-api";

export const loadQuestionCategories = createAsyncThunk<IQuestionCategory[]>(
  "questionCategories/loadQuestionCategories",
  async () => {
    return await getQuestionCategories();
  },
);
