import React from "react";
import { IQuestionCategory } from "../types/types";
import QuestionCategoriesList from "../components/qustion-categories-list";

const QuestionCategoriesPage: React.FC = () => {
  // TODO: Сделать запрос с сервера. Пока для тестиораня захардкожено.
  const categories: Array<IQuestionCategory> = [
    {
      id: 1,
      text: "Дорожные знаки",
    },
    {
      id: 2,
      text: "Разметка",
    },
  ];
  return (
    <>
      <QuestionCategoriesList categories={categories} />
    </>
  );
};

export default QuestionCategoriesPage;
