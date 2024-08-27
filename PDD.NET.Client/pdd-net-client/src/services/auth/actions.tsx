import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  IUser,
  ILoginRequest,
  ILoginResponse,
  IRegisterRequest,
  IRegisterResponse,
} from "../../types/types";
import { loginEndpoint, registerEndpoint } from "../../utils/auth-api";
import { AppDispatch } from "../store";
import { jwtDecode } from "jwt-decode";
import { setToken, setUser } from "./reducer";

export const register = createAsyncThunk<IRegisterResponse, IRegisterRequest>(
  "auth/register",
  registerEndpoint,
);

export const login = createAsyncThunk<
  ILoginResponse,
  ILoginRequest,
  { dispatch: AppDispatch }
>("auth/login", async (request, { dispatch }) => {
  try {
    const response = await loginEndpoint(request);
    if (response?.token) {
      const jwtDecoded = jwtDecode(response.token);
      if (jwtDecoded && (jwtDecoded as IUser)) {
        dispatch(setUser(jwtDecoded as IUser));
        dispatch(setToken(`Bearer ${response.token}`));
      }
    }

    return response;
  } catch (error: any) {
    throw error;
  }
});
