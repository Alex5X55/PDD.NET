import React from "react";
import { useParams, Link } from "react-router-dom";
import { mockData } from "../data/mock-data";

const QuestionCategoryPage: React.FC = () => {
  const { categoryId } = useParams<{ categoryId: string }>();
  const categoryInt = parseInt(categoryId || "", 10);
  const categoryName = mockData.categories.find(
    (category) => category.id === categoryInt,
  )?.text;

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">{categoryName}</h1>
      </header>
      <Link to={`/question-category/${categoryInt}/1`}>Начать вопросы</Link>
    </div>
  );
};

export default QuestionCategoryPage;
