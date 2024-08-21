import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import {
  ICreateQuestionRequest,
  IQuestionResponse,
  IQuestion,
  IUpdateQuestionRequest,
} from "../types/types";

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

export const addQuestion = async (
  requestData: ICreateQuestionRequest,
): Promise<IQuestionResponse> => {
  const res = await fetch(`${baseApiConfig.baseUrl}/questions`, {
    method: "POST",
    headers: baseApiConfig.headers,
    body: JSON.stringify(requestData),
  });
  return getResponse(res);
};

export const updateQuestionEndpoint = async (
  requestData: IUpdateQuestionRequest,
): Promise<IQuestionResponse> => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/questions/${requestData.id}`,
    {
      method: "POST",
      headers: baseApiConfig.headers,
      body: JSON.stringify(requestData),
    },
  );
  return getResponse(res);
};

export const removeQuestion = async (questionId: number) => {
  const res = await fetch(`${baseApiConfig.baseUrl}/questions/${questionId}`, {
    method: "DELETE",
    headers: baseApiConfig.headers,
  });
  return getResponse(res);
};
