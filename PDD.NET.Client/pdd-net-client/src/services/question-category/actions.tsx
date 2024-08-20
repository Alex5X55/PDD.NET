import {
  ICreateQuestionCategoryRequest,
  ICreateQuestionCategoryResponse,
  IQuestionCategory,
} from "../../types/types";
import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  addQuestionCategory,
  getAllQuestionCategories,
  removeQuestionCategory,
} from "../../utils/question-categories-api";

export const loadQuestionCategories = createAsyncThunk<IQuestionCategory[]>(
  "questionCategories/loadQuestionCategories",
  async () => {
    return await getAllQuestionCategories();
  },
);

export const createQuestionCategory = createAsyncThunk<
  ICreateQuestionCategoryResponse,
  ICreateQuestionCategoryRequest
>("questionCategories/createQuestionCategory", addQuestionCategory);

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
