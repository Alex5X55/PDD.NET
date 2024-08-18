import React from "react";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import ConfirmationDialog from "../components/confirmation-dialog";
import { resetDeletingItems, setIsShowModal } from "../services/modal/reducer";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";
import QuestionCategoryRowEdit from "../components/question-category-row-edit";
import {
  getDeletingQuestionCategory,
  getIsShowModal,
} from "../services/modal/selectors";
import { getQuestionCategories } from "../services/question-category/selectors";
import {
  deleteQuestionCategory,
  loadQuestionCategories,
} from "../services/question-category/actions";

const AdminQuestionCategoriesPage: React.FC = () => {
  const dispatch = useAppDispatch();

  const allCategories = useAppSelector(getQuestionCategories);

  const isShowModal = useAppSelector(getIsShowModal);
  const deletingCategory = useAppSelector(getDeletingQuestionCategory);

  const onApproveHandler = async () => {
    if (deletingCategory) {
      try {
        await dispatch(deleteQuestionCategory(deletingCategory.id)).unwrap();
      } catch (error) {
        console.error("Ошибка при удалении категории:", error);
      } finally {
        dispatch(loadQuestionCategories());
      }
    }

    dispatch(setIsShowModal(false));
    dispatch(resetDeletingItems());
  };

  const onRejectHandler = () => {
    dispatch(setIsShowModal(false));
    dispatch(resetDeletingItems());
  };

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Категории вопросов</h1>
      </header>
      <p className="lead">
        В этом разделе вы можете увидеть список всех категорий вопросов, а также
        редактировать их.
      </p>
      <div className="mb-2">
        <Link to={`/category/edit`} className="m-2">
          <Button variant="primary" size="lg">
            Добавить категорию
          </Button>
        </Link>
      </div>
      {allCategories.length > 0 ? (
        <table className="table table-striped">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Название категории</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            {allCategories.map((category) => (
              <QuestionCategoryRowEdit {...category} key={category.id} />
            ))}
          </tbody>
        </table>
      ) : (
        <div>Категории не найдены</div>
      )}
      <ConfirmationDialog
        show={isShowModal}
        onHide={onRejectHandler}
        title="Подтверждение удаления"
        body="Вы уверены, что хотите удалить эту категорию?"
        onApproveClick={onApproveHandler}
        onRejectClick={onRejectHandler}
      />
    </div>
  );
};

export default AdminQuestionCategoriesPage;
