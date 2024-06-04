import React from "react";
import { IQuestionCategoriesList } from "../types/types";
import { ListGroup } from "react-bootstrap";
import { Link } from "react-router-dom";

const QuestionCategoriesList: React.FC<IQuestionCategoriesList> = ({
  categories,
}) => {
  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Вопросы по темам</h1>
      </header>
      <p className="lead">
        В этом разделе вы можете выбрать конкретную категорию вопросов, которую
        хотите потренировать.
      </p>
      <ListGroup>
        {categories.map((item) => (
          <ListGroup.Item key={item.id}>
            <Link to={`/question-category/${item.id}`}>{item.text}</Link>
          </ListGroup.Item>
        ))}
      </ListGroup>
    </div>
  );
};

export default QuestionCategoriesList;
