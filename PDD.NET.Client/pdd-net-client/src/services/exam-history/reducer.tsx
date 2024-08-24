import { createSlice } from "@reduxjs/toolkit";
import { createExamHistory } from "./actions";
import { IExamHistoryResponse } from "../../types/types";

interface IExamHistoryState {
  examHistoryResponse: IExamHistoryResponse | null;
  createExamHistoryLoading: boolean;
  createExamHistoryError: string | null;
}

const initialState: IExamHistoryState = {
  examHistoryResponse: null,
  createExamHistoryLoading: false,
  createExamHistoryError: null,
};

export const examHistorySlice = createSlice({
  name: "examHistory",
  initialState,
  reducers: {
    resetExamHistoryState: (state) => {
      state.createExamHistoryError = null;
      state.examHistoryResponse = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(createExamHistory.pending, (state) => {
        state.createExamHistoryLoading = true;
        state.createExamHistoryError = null;
      })
      .addCase(createExamHistory.fulfilled, (state, action) => {
        state.examHistoryResponse = action.payload;
        state.createExamHistoryLoading = false;
      })
      .addCase(createExamHistory.rejected, (state, action) => {
        state.createExamHistoryLoading = false;
        state.createExamHistoryError = action?.error?.message as string;
      });
  },
});

export const { resetExamHistoryState } = examHistorySlice.actions;
