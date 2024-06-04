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
