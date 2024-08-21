import {
  ICreateQuestionCategoryRequest,
  IQuestionCategoryResponse,
  IQuestionCategory,
  IUpdateQuestionCategoryRequest,
} from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  addQuestionCategory,
  getAllQuestionCategories,
  removeQuestionCategory,
  updateQuestionCategoryEndpoint,
} from "../../utils/question-categories-api";

export const loadQuestionCategories = createAsyncThunk<IQuestionCategory[]>(
  "questionCategories/loadQuestionCategories",
  async () => {
    return await getAllQuestionCategories();
  },
);

export const createQuestionCategory = createAsyncThunk<
  IQuestionCategoryResponse,
  ICreateQuestionCategoryRequest
>("questionCategories/createQuestionCategory", addQuestionCategory);

export const updateQuestionCategory = createAsyncThunk<
  IQuestionCategoryResponse,
  IUpdateQuestionCategoryRequest
>("questionCategories/updateQuestionCategory", updateQuestionCategoryEndpoint);

export const deleteQuestionCategory = createAsyncThunk<void, number>(
  "questionCategories/deleteQuestionCategory",
  async (questionId, { rejectWithValue }) => {
    try {
      await removeQuestionCategory(questionId);
    } catch (error) {
      return rejectWithValue(error);
    }
  },
);
