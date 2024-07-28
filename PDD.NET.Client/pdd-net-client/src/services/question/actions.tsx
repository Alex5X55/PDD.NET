import { IQuestion } from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import { getQuestionsByCategory } from "../../utils/questions-api";

export const loadQuestionsByCategory = createAsyncThunk<IQuestion[], number>(
  "questions/loadQuestionCategories",
  async (questionCategoryId) => {
    return await getQuestionsByCategory(questionCategoryId);
  },
);
