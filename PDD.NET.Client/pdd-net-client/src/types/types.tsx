export interface IRegisterForm {
  login: string;
  email: string;
  password: string;
  confirmPassword: string;
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

export interface ICreateQuestionCategoryRequest {
  text: string;
}

export interface IUpdateQuestionCategoryRequest {
  id: number;
  text: string;
}

export interface IQuestionCategoryResponse {
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

export interface ICreateAnswerOptionRequest {
  text: string;
  questionId: number;
  isRight: boolean;
}

export interface IUpdateAnswerOptionRequest {
  id: number;
  text: string;
  questionId: number;
  isRight: boolean;
}

export interface IQuestion {
  id: number;
  categoryId: number;
  imageData: string;
  text: string;
  category: IQuestionCategory;
  answerOptions: Array<IAnswerOption>;
}

export interface ICreateQuestionRequest {
  categoryId: number;
  imageData: string;
  text: string;
}

export interface IQuestionResponse {
  id: number;
  categoryId: number;
  imageData: string;
  text: string;
}

export interface IUpdateQuestionRequest {
  id: number;
  categoryId: number;
  imageData: string;
  text: string;
}

export interface IAnswer {
  answerId: number;
  questionId: number;
  isRight: boolean;
}

export interface IQuestionList {
  questions: Array<IQuestion>;
  initNumberQuestion: number;
}

export interface IIconProps {
  onClick: () => void;
}

export interface IConfirmationDialog {
  title: string;
  body: string;
  onApproveClick: () => void;
  onRejectClick: () => void;
  show: boolean;
  onHide: () => void;
}

export interface ICreateExamHistoryRequest {
  login: string;
  isSuccess: boolean;
}

export interface IExamHistoryResponse {
  login: string;
  isSuccess: boolean;
}

export interface IRegisterRequest {
  login: string;
  password: string;
  email: string;
}

export interface IRegisterResponse {
  id: number;
  login: string;
  email: string;
}

export interface ILoginRequest {
  email: string;
  password: string;
}

export interface ILoginResponse {
  token: string;
  refreshToken: string;
  success: boolean;
  errors: string[];
}

export interface IUser {
  id: number;
  email: string;
  name: string;
  role: string;
}

export interface IAnalyticsData {
  createdOn: string;
  login: string;
  isSuccess: boolean;
}
