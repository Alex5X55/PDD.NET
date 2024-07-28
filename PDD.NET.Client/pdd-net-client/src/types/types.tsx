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

export interface IAnswerOption {
  id: number;
  questionId: number;
  text: string;
  isRight: boolean;
}

export interface IQuestion {
  id: number;
  categoryId: number;
  imageData: string;
  text: string;
  answerOptions: Array<IAnswerOption>;
}

export interface IAnswer {
  answerId: number;
  questionId: number;
  isRight: boolean;
}

export interface IQuestionList {
  questions: Array<IQuestion>;
}
