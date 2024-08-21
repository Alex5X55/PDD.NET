import { createSlice } from "@reduxjs/toolkit";
import { IAnswerOption } from "../../types/types";
import { createAnswerOption, updateAnswerOption } from "./actions";

interface IAnswerOptionState {
  answerOptionResponse: IAnswerOption | null;

  createAnswerOptionLoading: boolean;
  createAnswerOptionError: string | null;

  updateAnswerOptionLoading: boolean;
  updateAnswerOptionError: string | null;
}

const initialState: IAnswerOptionState = {
  answerOptionResponse: null,

  createAnswerOptionLoading: false,
  createAnswerOptionError: null,

  updateAnswerOptionLoading: false,
  updateAnswerOptionError: null,
};

export const answerOptionsSlice = createSlice({
  name: "answerOptions",
  initialState,
  reducers: {
    resetAnswerOptionState: (state) => {
      state.answerOptionResponse = null;
      state.createAnswerOptionError = null;
      state.updateAnswerOptionError = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(createAnswerOption.pending, (state) => {
        state.createAnswerOptionLoading = true;
        state.createAnswerOptionError = null;
      })
      .addCase(createAnswerOption.fulfilled, (state, action) => {
        state.answerOptionResponse = action.payload;
        state.createAnswerOptionLoading = false;
      })
      .addCase(createAnswerOption.rejected, (state, action) => {
        state.createAnswerOptionLoading = false;
        state.createAnswerOptionError = action?.error?.message as string;
      })
      .addCase(updateAnswerOption.pending, (state) => {
        state.updateAnswerOptionLoading = true;
        state.updateAnswerOptionError = null;
      })
      .addCase(updateAnswerOption.fulfilled, (state, action) => {
        state.answerOptionResponse = action.payload;
        state.updateAnswerOptionLoading = false;
      })
      .addCase(updateAnswerOption.rejected, (state, action) => {
        state.updateAnswerOptionLoading = false;
        state.updateAnswerOptionError = action?.error?.message as string;
      });
  },
});

export const { resetAnswerOptionState } = answerOptionsSlice.actions;
