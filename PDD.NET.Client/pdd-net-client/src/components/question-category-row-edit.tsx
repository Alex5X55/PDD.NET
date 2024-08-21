import React from "react";
import { IQuestionCategory } from "../types/types";
import TrashIcon from "./trash-icon";
import EditIcon from "./edit-icon";
import { useAppDispatch } from "../services/hooks";
import { Link } from "react-router-dom";
import {
  setDeletingQuestionCategory,
  setIsShowModal,
} from "../services/modal/reducer";

const QuestionCategoryRowEdit: React.FC<IQuestionCategory> = (
  questionCategory,
) => {
  const dispatch = useAppDispatch();

  const handleDeleteClick = (category: IQuestionCategory) => {
    dispatch(setDeletingQuestionCategory(category));
    dispatch(setIsShowModal(true));
  };

  return (
    <>
      <tr key={questionCategory.id}>
        <td>{questionCategory.id}</td>
        <td>
          <b>{questionCategory.text}</b>
        </td>
        <td>
          <Link to={`/question-category/edit/${questionCategory.id}`}>
            <EditIcon />
          </Link>
          <TrashIcon onClick={() => handleDeleteClick(questionCategory)} />
        </td>
      </tr>
    </>
  );
};

export default QuestionCategoryRowEdit;
