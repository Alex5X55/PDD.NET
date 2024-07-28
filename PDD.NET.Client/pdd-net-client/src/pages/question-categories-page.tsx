import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import {
  getQuestionCategories,
  getQuestionCategoriesError,
  getQuestionCategoriesLoading,
} from "../services/question-category/selectors";
import Preloader from "../components/preloader/preloader";
import { resetCurrentAnswers } from "../services/answer/reducer";
import "./pages.css";

const QuestionCategoriesPage: React.FC = () => {
  const dispatch = useAppDispatch();

  const isLoading = useAppSelector(getQuestionCategoriesLoading);
  const error = useAppSelector(getQuestionCategoriesError);
  const questionCategories = useAppSelector(getQuestionCategories);

  useEffect(() => {
    dispatch(resetCurrentAnswers());
  }, [dispatch]);

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
        <div className="d-grid gap-2">
          {questionCategories.map((item) => (
            <Link key={item.id} to={`/question-category/${item.id}`}>
              <Button variant="primary" size="lg">
                {item.text}
              </Button>
            </Link>
          ))}
        </div>
      )}
    </div>
  );
};

export default QuestionCategoriesPage;
