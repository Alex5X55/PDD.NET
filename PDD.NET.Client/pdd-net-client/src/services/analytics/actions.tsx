import { createAsyncThunk } from "@reduxjs/toolkit";
import { IAnalyticsData } from "../../types/types";
import {
  getAnalyticsDataEndpoint,
  getUserAnalyticsDataEndpoint,
} from "../../utils/analytics-api";

export const getAnalyticsData = createAsyncThunk<IAnalyticsData[]>(
  "analyticsData/getAnalyticsData",
  getAnalyticsDataEndpoint,
);

export const getUserAnalyticsData = createAsyncThunk<IAnalyticsData[], string>(
  "analyticsData/getUserAnalyticsData",
  getUserAnalyticsDataEndpoint,
);
