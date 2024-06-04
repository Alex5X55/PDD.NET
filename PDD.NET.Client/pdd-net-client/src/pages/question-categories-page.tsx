import React from "react";
import { IQuestionCategory } from "../types/types";
import QuestionCategoriesList from "../components/question-categories-list";
import { mockData } from "../data/mock-data";

const QuestionCategoriesPage: React.FC = () => {
  // TODO: Сделать запрос с сервера. Пока для тестирования захардкожено.
  const categories: Array<IQuestionCategory> = mockData.categories;
  return (
    <>
      <QuestionCategoriesList categories={categories} />
    </>
  );
};

export default QuestionCategoriesPage;
