import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import { IQuestionCategory } from "../types/types";

export const getAllQuestionCategories = async (): Promise<
  IQuestionCategory[]
> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/question-categories`, {
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};

export const removeQuestionCategory = async (questionCategoryId: number) => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/question-categories/${questionCategoryId}`,
    {
      method: "DELETE",
      headers: baseApiConfig.headers,
    },
  );
  return getResponse(res);
};
