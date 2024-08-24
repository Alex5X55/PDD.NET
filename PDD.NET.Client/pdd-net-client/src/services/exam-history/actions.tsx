import { createAsyncThunk } from "@reduxjs/toolkit";
import {
  ICreateExamHistoryRequest,
  IExamHistoryResponse,
} from "../../types/types";
import { createExamHistoryEndpoint } from "../../utils/exam-history-api";

export const createExamHistory = createAsyncThunk<
  IExamHistoryResponse,
  ICreateExamHistoryRequest
>("examHistory/createExamHistory", createExamHistoryEndpoint);
