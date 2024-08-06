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
import ConfirmationDialog from "../components/confirmation-dialog";
import { getIsShowModal } from "../services/modal/selectors";
import { setIsShowModal } from "../services/modal/reducer";

const AdminQuestionsPage: React.FC = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(loadAllQuestions());
  }, [dispatch]);

  const allQuestions = useAppSelector(getAllQuestions);
  const isLoading = useAppSelector(getAllQuestionsLoading);
  const error = useAppSelector(getAllQuestionsError);

  const isShowModal = useAppSelector(getIsShowModal);

  const onHide = () => {
    dispatch(setIsShowModal(false));
  };

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
              <th scope="col">Текст вопроса/варианта ответа</th>
              <th scope="col">Категория</th>
              <th scope="col">Правильный ответ?</th>
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
      <ConfirmationDialog
        show={isShowModal}
        onHide={onHide}
        title="Подтверждение удаления"
        body="Вы уверены, что хотите удалить этот элемент?"
        onApproveClick={onHide}
        onRejectClick={onHide}
      />
    </div>
  );
};

export default AdminQuestionsPage;
