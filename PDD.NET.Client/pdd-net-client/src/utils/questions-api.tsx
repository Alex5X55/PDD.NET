import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import { IQuestion } from "../types/types";

export const getQuestionsByCategory = async (
  questionCategoryId: number,
): Promise<IQuestion[]> => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/questions/category/${questionCategoryId}`,
    {
      method: "GET",
      headers: baseApiConfig.headers,
    },
  );
  return getResponse(res);
};

export const getExamQuestions = async (): Promise<IQuestion[]> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/questions`, {
    method: "GET",
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};

export const getQuestions = async (): Promise<IQuestion[]> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/questions`, {
    method: "GET",
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};

export const removeQuestion = async (questionId: number) => {
  const res = await fetch(`${baseApiConfig.baseUrl}/questions/${questionId}`, {
    method: "DELETE",
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};
