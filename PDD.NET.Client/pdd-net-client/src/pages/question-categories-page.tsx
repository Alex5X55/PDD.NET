import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { ListGroup } from "react-bootstrap";
import { Link } from "react-router-dom";
import {
  getQuestionCategories,
  getQuestionCategoriesError,
  getQuestionCategoriesLoading,
} from "../services/question-category/selectors";
import Preloader from "../components/preloader/preloader";
import { resetCurrentAnswers } from "../services/answer/reducer";

const QuestionCategoriesPage: React.FC = () => {
  const dispatch = useAppDispatch();

  const isLoading = useAppSelector(getQuestionCategoriesLoading);
  const error = useAppSelector(getQuestionCategoriesError);
  const questionCategories = useAppSelector(getQuestionCategories);

  useEffect(() => {
    dispatch(resetCurrentAnswers());
  }, []);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Вопросы по темам</h1>
      </header>
      <p className="lead">
        В этом разделе вы можете выбрать конкретную категорию вопросов, которую
        хотите потренировать.
      </p>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      {questionCategories && questionCategories.length > 0 && (
        <ListGroup>
          {questionCategories.map((item) => (
            <ListGroup.Item key={item.id}>
              <Link to={`/question-category/${item.id}`}>{item.text}</Link>
            </ListGroup.Item>
          ))}
        </ListGroup>
      )}
    </div>
  );
};

export default QuestionCategoriesPage;
