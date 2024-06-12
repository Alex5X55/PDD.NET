import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import { IQuestionCategory } from "../types/types";
import { IQuestionCategoriesApiResponse } from "../types/api-types";

export const getQuestionCategories = async (): Promise<IQuestionCategory[]> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/question-categories`, {
    headers: baseApiConfig.headers,
  });
  return getResponse(res, (data) => data as IQuestionCategory[]);
};
