import { createAsyncThunk } from "@reduxjs/toolkit";
import { IAnalyticsData } from "../../types/types";
import { getAnalyticsDataEndpoint } from "../../utils/analytics-api";

export const getAnalyticsData = createAsyncThunk<IAnalyticsData[]>(
  "analyticsData/getAnalyticsData",
  getAnalyticsDataEndpoint,
);
