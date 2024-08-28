import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import {
  ICreateQuestionCategoryRequest,
  IQuestionCategoryResponse,
  IQuestionCategory,
  IUpdateQuestionCategoryRequest,
} from "../types/types";

export const getAllQuestionCategories = async (): Promise<
  IQuestionCategory[]
> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/question-categories`, {
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};

export const addQuestionCategory = async (
  requestData: ICreateQuestionCategoryRequest,
): Promise<IQuestionCategoryResponse> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/question-categories`, {
    method: "POST",
    headers: {
      ...baseApiConfig.headers,
      Authorization: localStorage.getItem("token") || "",
    },
    body: JSON.stringify(requestData),
  });
  return getResponse(res);
};

export const updateQuestionCategoryEndpoint = async (
  requestData: IUpdateQuestionCategoryRequest,
): Promise<IQuestionCategoryResponse> => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/question-categories/${requestData.id}`,
    {
      method: "POST",
      headers: {
        ...baseApiConfig.headers,
        Authorization: localStorage.getItem("token") || "",
      },
      body: JSON.stringify(requestData),
    },
  );
  return getResponse(res);
};

export const removeQuestionCategory = async (questionCategoryId: number) => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/question-categories/${questionCategoryId}`,
    {
      method: "DELETE",
      headers: {
        ...baseApiConfig.headers,
        Authorization: localStorage.getItem("token") || "",
      },
    },
  );
  return getResponse(res);
};
