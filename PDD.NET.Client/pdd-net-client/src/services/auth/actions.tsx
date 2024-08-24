import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  ILoginRequest,
  ILoginResponse,
  IRegisterRequest,
  IRegisterResponse,
} from "../../types/types";
import { loginEndpoint, registerEndpoint } from "../../utils/auth-api";

export const register = createAsyncThunk<IRegisterResponse, IRegisterRequest>(
  "auth/register",
  registerEndpoint,
);

export const login = createAsyncThunk<ILoginResponse, ILoginRequest>(
  "auth/login",
  loginEndpoint,
);
