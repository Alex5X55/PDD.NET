import { RootState } from "../store";

export const getAnalyticsDataResponse = (state: RootState) =>
  state.analytics.analyticsDataResponse;

export const getAnalyticsDataError = (state: RootState) =>
  state.analytics.getAnalyticsDataError;

export const getAnalyticsDataLoading = (state: RootState) =>
  state.analytics.getAnalyticsDataLoading;
