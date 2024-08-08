import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";

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
