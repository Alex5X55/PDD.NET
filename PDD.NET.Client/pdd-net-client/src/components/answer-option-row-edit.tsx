import React from "react";
import { IAnswerOption } from "../types/types";
import TrashIcon from "./trash-icon";
import EditIcon from "./edit-icon";
import { useAppDispatch } from "../services/hooks";
import { setDeletingAnswer, setIsShowModal } from "../services/modal/reducer";
import { Link } from "react-router-dom";

const AnswerOptionRowEdit: React.FC<IAnswerOption> = (answerOption) => {
  const dispatch = useAppDispatch();

  const handleDeleteClick = (answerOption: IAnswerOption) => {
    dispatch(setDeletingAnswer(answerOption));
    dispatch(setIsShowModal(true));
  };

  return (
    <>
      <tr key={answerOption.id}>
        <td>{answerOption.id}</td>
        <td>{answerOption.text}</td>
        <td></td>
        <td>{answerOption.isRight ? "Да" : "Нет"}</td>
        <td>
          <Link to={`/answer-option/edit/${answerOption.id}`}>
            <EditIcon />
          </Link>
        </td>
        <td>
          <TrashIcon onClick={() => handleDeleteClick(answerOption)} />
        </td>
      </tr>
    </>
  );
};

export default AnswerOptionRowEdit;
