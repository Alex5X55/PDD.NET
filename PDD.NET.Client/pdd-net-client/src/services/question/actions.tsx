import { IQuestion } from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  getExamQuestions,
  getQuestionsByCategory,
} from "../../utils/questions-api";

export const loadQuestionsByCategory = createAsyncThunk<IQuestion[], number>(
  "questions/loadQuestionCategories",
  async (questionCategoryId) => {
    return await getQuestionsByCategory(questionCategoryId);
  },
);

export const loadExamQuestions = createAsyncThunk<IQuestion[]>(
  "questions/loadExamQuestions",
  async (questionCategoryId) => {
    return await getExamQuestions();
  },
);
