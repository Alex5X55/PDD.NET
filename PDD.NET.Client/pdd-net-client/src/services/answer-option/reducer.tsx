import { createSlice } from "@reduxjs/toolkit";
import { IAnswerOption } from "../../types/types";
import { createAnswerOption } from "./actions";

interface IAnswerOptionState {
  newAnswerOption: IAnswerOption | null;
  createAnswerOptionLoading: boolean;
  createAnswerOptionError: string | null;
}

const initialState: IAnswerOptionState = {
  newAnswerOption: null,
  createAnswerOptionLoading: false,
  createAnswerOptionError: null,
};

export const answerOptionsSlice = createSlice({
  name: "answerOptions",
  initialState,
  reducers: {
    resetAnswerOptionState: (state) => {
      state.newAnswerOption = null;
      state.createAnswerOptionError = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(createAnswerOption.pending, (state) => {
        state.createAnswerOptionLoading = true;
        state.createAnswerOptionError = null;
      })
      .addCase(createAnswerOption.fulfilled, (state, action) => {
        state.newAnswerOption = action.payload;
        state.createAnswerOptionLoading = false;
      })
      .addCase(createAnswerOption.rejected, (state, action) => {
        state.createAnswerOptionLoading = false;
        state.createAnswerOptionError = action?.error?.message as string;
      });
  },
});

export const { resetAnswerOptionState } = answerOptionsSlice.actions;
