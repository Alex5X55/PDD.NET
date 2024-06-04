import React from "react";
import { useAppSelector } from "../services/hooks";
import { getQuestionCategories } from "../services/question/selectors";
import { ListGroup } from "react-bootstrap";
import { Link } from "react-router-dom";

const QuestionCategoriesPage: React.FC = () => {
  const questionCategories = useAppSelector(getQuestionCategories);

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
        {questionCategories.map((item) => (
          <ListGroup.Item key={item.id}>
            <Link to={`/question-category/${item.id}`}>{item.text}</Link>
          </ListGroup.Item>
        ))}
      </ListGroup>
    </div>
  );
};

export default QuestionCategoriesPage;
