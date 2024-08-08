import { createAsyncThunk } from "@reduxjs/toolkit";
import { removeAnswerOption } from "../../utils/answer-options-api";

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
