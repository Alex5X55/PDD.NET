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

export interface IQuestionCategory {
  id: number;
  text: string;
}

export interface IQuestionCategoriesList {
  categories: Array<IQuestionCategory>;
}

export interface IQuestion {
  id: number;
  categoryId: number;
  imageData: string;
  text: string;
}

export interface IAnswerOption {
  id: number;
  questionId: number;
  text: string;
  isRight: boolean;
}
