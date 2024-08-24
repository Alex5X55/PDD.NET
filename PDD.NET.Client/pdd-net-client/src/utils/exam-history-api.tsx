import {
  ICreateExamHistoryRequest,
  IExamHistoryResponse,
} from "../types/types";
import { baseApiConfig } from "../data/api-config";
import getResponse from "./api-utils";

export const createExamHistoryEndpoint = async (
  requestData: ICreateExamHistoryRequest,
): Promise<IExamHistoryResponse> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/user-answer/exam-history`, {
    method: "POST",
    headers: baseApiConfig.headers,
    body: JSON.stringify(requestData),
  });
  return getResponse(res);
};
