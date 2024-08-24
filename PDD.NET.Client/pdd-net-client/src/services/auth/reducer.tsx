import { createSlice } from "@reduxjs/toolkit";
import { ILoginResponse, IRegisterResponse } from "../../types/types";
import { login, register } from "./actions";

interface IAuthState {
  registerResponse: IRegisterResponse | null;
  registerLoading: boolean;
  registerError: string | null;

  loginResponse: ILoginResponse | null;
  loginLoading: boolean;
  loginError: string | null;
}

const initialState: IAuthState = {
  registerResponse: null,
  registerLoading: false,
  registerError: null,

  loginResponse: null,
  loginLoading: false,
  loginError: null,
};

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    resetRegisterState: (state) => {
      state.registerError = null;
      state.registerResponse = null;
    },
    resetLoginState: (state) => {
      state.loginError = null;
      state.loginResponse = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(register.pending, (state) => {
        state.registerLoading = true;
        state.registerError = null;
      })
      .addCase(register.fulfilled, (state, action) => {
        state.registerResponse = action.payload;
        state.registerLoading = false;
      })
      .addCase(register.rejected, (state, action) => {
        state.registerLoading = false;
        state.registerError = action?.error?.message as string;
      })
      .addCase(login.pending, (state) => {
        state.loginLoading = true;
        state.loginError = null;
      })
      .addCase(login.fulfilled, (state, action) => {
        state.loginResponse = action.payload;
        state.loginLoading = false;
      })
      .addCase(login.rejected, (state, action) => {
        state.loginLoading = false;
        state.loginError = action?.error?.message as string;
      });
  },
});

export const { resetRegisterState, resetLoginState } = authSlice.actions;