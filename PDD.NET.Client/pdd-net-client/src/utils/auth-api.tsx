import getResponse from "./api-utils";
import { baseApiConfig } from "../data/api-config";
import {
  ILoginRequest,
  ILoginResponse,
  IRegisterRequest,
  IRegisterResponse,
} from "../types/types";

export const registerEndpoint = async (
  requestData: IRegisterRequest,
): Promise<IRegisterResponse> => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/authorization/manager/register`,
    {
      method: "POST",
      headers: baseApiConfig.headers,
      body: JSON.stringify(requestData),
    },
  );
  return getResponse(res);
};

export const loginEndpoint = async (
  requestData: ILoginRequest,
): Promise<ILoginResponse> => {
  const res = await fetch(
    `${baseApiConfig.baseUrl}/authorization/manager/login`,
    {
      method: "POST",
      headers: baseApiConfig.headers,
      body: JSON.stringify(requestData),
    },
  );
  return getResponse(res);
};
