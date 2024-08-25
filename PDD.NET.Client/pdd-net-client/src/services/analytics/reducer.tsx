import { createSlice } from "@reduxjs/toolkit";
import { getAnalyticsData } from "./actions";
import { IAnalyticsData } from "../../types/types";

interface IAnalyticsDataState {
  analyticsDataResponse: IAnalyticsData[] | [];
  getAnalyticsDataLoading: boolean;
  getAnalyticsDataError: string | null;
}

const initialState: IAnalyticsDataState = {
  analyticsDataResponse: [],
  getAnalyticsDataLoading: false,
  getAnalyticsDataError: null,
};

export const analyticsDataSlice = createSlice({
  name: "analyticsData",
  initialState,
  reducers: {
    resetAnalyticsDataState: (state) => {
      state.getAnalyticsDataError = null;
      state.analyticsDataResponse = [];
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getAnalyticsData.pending, (state) => {
        state.getAnalyticsDataLoading = true;
        state.getAnalyticsDataError = null;
      })
      .addCase(getAnalyticsData.fulfilled, (state, action) => {
        state.analyticsDataResponse = action.payload;
        state.getAnalyticsDataLoading = false;
      })
      .addCase(getAnalyticsData.rejected, (state, action) => {
        state.getAnalyticsDataLoading = false;
        state.getAnalyticsDataError = action?.error?.message as string;
      });
  },
});

export const { resetAnalyticsDataState } = analyticsDataSlice.actions;
