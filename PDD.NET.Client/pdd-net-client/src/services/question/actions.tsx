import { IQuestion } from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  getQuestions,
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

export const loadAllQuestions = createAsyncThunk<IQuestion[]>(
  "questions/loadAllQuestions",
  async (questionCategoryId) => {
    return await getQuestions();
  },
);
