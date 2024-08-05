import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import {
  getAllQuestions,
  getAllQuestionsError,
  getAllQuestionsLoading,
} from "../services/question/selectors";
import Preloader from "../components/preloader/preloader";
import { loadAllQuestions } from "../services/question/actions";

const AdminQuestionsPage: React.FC = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(loadAllQuestions());
  }, [dispatch]);

  const allQuestions = useAppSelector(getAllQuestions);
  const isLoading = useAppSelector(getAllQuestionsLoading);
  const error = useAppSelector(getAllQuestionsError);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Вопросы</h1>
      </header>
      <p className="lead">
        В этом разделе вы можете получить все вопросы, а также редактировать
        вопросы и варианты ответов.
      </p>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      {allQuestions.length > 0 ? (
        <div className="d-grid gap-2">
          <div className="container">
            <div className="row">
              <div className="col-1">Id</div>
              <div className="col-8">Текст вопроса</div>
              <div className="col">Категория</div>
            </div>
            {allQuestions.map((item) => (
              <div className="row" key={item.id}>
                <div className="col-1">{item.id}</div>
                <div className="col-8">{item.text}</div>
                <div className="col">{item.category?.text}</div>
              </div>
            ))}
          </div>
        </div>
      ) : (
        <div>Вопросы не найдены</div>
      )}
    </div>
  );
};

export default AdminQuestionsPage;
