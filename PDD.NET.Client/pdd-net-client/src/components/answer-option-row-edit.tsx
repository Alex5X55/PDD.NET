import React from "react";
import { IAnswerOption } from "../types/types";
import TrashIcon from "./trash-icon";
import EditIcon from "./edit-icon";
import { useAppDispatch } from "../services/hooks";
import { setIsShowModal } from "../services/modal/reducer";

const AnswerOptionRowEdit: React.FC<IAnswerOption> = (answerOption) => {
  const dispatch = useAppDispatch();

  const handleEditClick = (id: number) => {
    console.log("Edit:", id);
  };

  const handleDeleteClick = (id: number) => {
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
          <EditIcon onClick={() => handleEditClick(answerOption.id)} />
          <TrashIcon onClick={() => handleDeleteClick(answerOption.id)} />
        </td>
      </tr>
    </>
  );
};

export default AnswerOptionRowEdit;
