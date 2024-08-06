import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import {
  getAllQuestions,
  getAllQuestionsError,
  getAllQuestionsLoading,
} from "../services/question/selectors";
import Preloader from "../components/preloader/preloader";
import { loadAllQuestions } from "../services/question/actions";
import QuestionRowEdit from "../components/question-row-edit";

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
        <table className="table table-striped">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Текст вопроса</th>
              <th scope="col">Категория</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            {allQuestions.map((item) => (
              <QuestionRowEdit {...item} key={item.id} />
            ))}
          </tbody>
        </table>
      ) : (
        <div>Вопросы не найдены</div>
      )}
    </div>
  );
};

export default AdminQuestionsPage;
