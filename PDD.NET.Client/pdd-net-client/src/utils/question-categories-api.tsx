import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import { IQuestionCategory } from "../types/types";

export const getQuestionCategories = async (): Promise<IQuestionCategory[]> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/question-categories`, {
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};
