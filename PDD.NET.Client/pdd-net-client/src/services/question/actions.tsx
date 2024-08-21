import {
  ICreateQuestionRequest,
  IQuestionResponse,
  IQuestion,
  IUpdateQuestionRequest,
} from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  getQuestions,
  getExamQuestions,
  getQuestionsByCategory,
  removeQuestion,
  addQuestion,
  updateQuestionEndpoint,
} from "../../utils/questions-api";

export const loadQuestionsByCategory = createAsyncThunk<IQuestion[], number>(
  "questions/loadQuestionCategories",
  async (questionCategoryId) => {
    return await getQuestionsByCategory(questionCategoryId);
  },
);

export const loadExamQuestions = createAsyncThunk<IQuestion[]>(
  "questions/loadExamQuestions",
  getExamQuestions,
);

export const loadAllQuestions = createAsyncThunk<IQuestion[]>(
  "questions/loadAllQuestions",
  getQuestions,
);

export const createQuestion = createAsyncThunk<
  IQuestionResponse,
  ICreateQuestionRequest
>("questionCategories/createQuestion", addQuestion);

export const updateQuestion = createAsyncThunk<
  IQuestionResponse,
  IUpdateQuestionRequest
>("questionCategories/updateQuestion", updateQuestionEndpoint);

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
