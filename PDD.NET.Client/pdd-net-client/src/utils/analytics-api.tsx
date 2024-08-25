import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import { IAnalyticsData } from "../types/types";

export const getAnalyticsDataEndpoint = async (): Promise<IAnalyticsData[]> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/analytics`, {
    method: "GET",
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};
