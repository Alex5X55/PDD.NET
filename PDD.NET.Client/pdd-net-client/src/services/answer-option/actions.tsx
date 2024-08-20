import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  createAnswerOptionEndpoint,
  removeAnswerOption,
} from "../../utils/answer-options-api";
import { IAnswerOption, ICreateAnswerOptionRequest } from "../../types/types";

export const createAnswerOption = createAsyncThunk<
  IAnswerOption,
  ICreateAnswerOptionRequest
>("questionCategories/createAnswerOption", createAnswerOptionEndpoint);

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
