import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  createAnswerOptionEndpoint,
  removeAnswerOption,
  updateAnswerOptionEndpoint,
} from "../../utils/answer-options-api";
import {
  IAnswerOption,
  ICreateAnswerOptionRequest,
  IUpdateAnswerOptionRequest,
} from "../../types/types";

export const createAnswerOption = createAsyncThunk<
  IAnswerOption,
  ICreateAnswerOptionRequest
>("questionCategories/createAnswerOption", createAnswerOptionEndpoint);

export const updateAnswerOption = createAsyncThunk<
  IAnswerOption,
  IUpdateAnswerOptionRequest
>("questionCategories/updateQuestionCategory", updateAnswerOptionEndpoint);

export const deleteAnswerOption = createAsyncThunk<void, number>(
  "answerOptions/deleteAnswerOption",
  async (answerOptionId, { rejectWithValue }) => {
    try {
      await removeAnswerOption(answerOptionId);
    } catch (error) {
      return rejectWithValue(error);
    }
  },
);
