import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import { IAnswerOption, ICreateAnswerOptionRequest } from "../types/types";

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
