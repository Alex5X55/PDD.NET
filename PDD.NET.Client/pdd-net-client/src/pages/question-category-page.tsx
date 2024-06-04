import React from "react";
import { useParams } from "react-router-dom";
import { mockData } from "../data/mock-data";

const QuestionCategoryPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const categoryId = parseInt(id || "", 10);
  const categoryName = mockData.categories.find(
    (c) => c.id === categoryId,
  )?.text;

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">{categoryName}</h1>
      </header>
    </div>
  );
};

export default QuestionCategoryPage;
