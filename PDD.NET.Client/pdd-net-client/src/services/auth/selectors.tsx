import { RootState } from "../store";

export const getRegisterResponse = (state: RootState) =>
  state.auth.registerResponse;

export const getRegisterLoading = (state: RootState) =>
  state.auth.registerLoading;

export const getRegisterError = (state: RootState) => state.auth.registerError;

export const getLoginResponse = (state: RootState) => state.auth.loginResponse;

export const getLoginLoading = (state: RootState) => state.auth.loginLoading;

export const getLoginError = (state: RootState) => state.auth.loginError;
