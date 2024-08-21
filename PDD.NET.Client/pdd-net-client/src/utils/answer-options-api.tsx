import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import {
  IAnswerOption,
  ICreateAnswerOptionRequest,
  IUpdateAnswerOptionRequest,
} from "../types/types";

export const createAnswerOptionEndpoint = async (
  requestData: ICreateAnswerOptionRequest,
): Promise<IAnswerOption> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/answer-options`, {
    method: "POST",
    headers: baseApiConfig.headers,
    body: JSON.stringify(requestData),
  });
  return getResponse(res);
};

export const updateAnswerOptionEndpoint = async (
  requestData: IUpdateAnswerOptionRequest,
): Promise<IAnswerOption> => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/answer-options/${requestData.id}`,
    {
      method: "POST",
      headers: baseApiConfig.headers,
      body: JSON.stringify(requestData),
    },
  );
  return getResponse(res);
};

export const removeAnswerOption = async (answerOptionId: number) => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/answer-options/${answerOptionId}`,
    {
      method: "DELETE",
      headers: baseApiConfig.headers,
    },
  );
  return getResponse(res);
};
