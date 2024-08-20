import {
  ICreateQuestionRequest,
  ICreateQuestionResponse,
  IQuestion,
} from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  getQuestions,
  getExamQuestions,
  getQuestionsByCategory,
  removeQuestion,
  addQuestion,
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

export const createQuestion = createAsyncThunk<
  ICreateQuestionResponse,
  ICreateQuestionRequest
>("questionCategories/createQuestion", addQuestion);

export const deleteQuestion = createAsyncThunk<void, number>(
  "questions/deleteQuestion",
  async (questionId, { rejectWithValue }) => {
    try {
      await removeQuestion(questionId);
    } catch (error) {
      return rejectWithValue(error);
    }
  },
);
