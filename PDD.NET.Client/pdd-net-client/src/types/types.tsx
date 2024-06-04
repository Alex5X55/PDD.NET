export interface IRegisterRequest {
  login: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface ILoginRequest {
  login: string;
  password: string;
}

export interface IRestorePasswordRequest {
  email: string;
}

export interface IResetPasswordRequest {
  password: string;
  confirmPassword: string;
}
