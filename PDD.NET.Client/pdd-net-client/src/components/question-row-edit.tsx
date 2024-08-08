import React from "react";
import { IQuestion } from "../types/types";
import TrashIcon from "./trash-icon";
import EditIcon from "./edit-icon";
import { useAppDispatch } from "../services/hooks";
import { setDeletingQuestion, setIsShowModal } from "../services/modal/reducer";
import AnswerOptionRowEdit from "./answer-option-row-edit";
import { Link } from "react-router-dom";

const QuestionRowEdit: React.FC<IQuestion> = (question) => {
  const dispatch = useAppDispatch();

  const handleDeleteClick = (question: IQuestion) => {
    dispatch(setDeletingQuestion(question));
    dispatch(setIsShowModal(true));
  };

  return (
    <>
      <tr key={question.id}>
        <td>{question.id}</td>
        <td>
          <b>{question.text}</b>
        </td>
        <td>{question.category?.text}</td>
        <td></td>
        <td>
          <Link to={`/question/edit/${question.id}`}>
            <EditIcon />
          </Link>
          <TrashIcon onClick={() => handleDeleteClick(question)} />
        </td>
      </tr>
      {question.answerOptions.length > 0 ? (
        <>
          {question.answerOptions.map((item) => (
            <AnswerOptionRowEdit {...item} key={item.id} />
          ))}
        </>
      ) : (
        <tr key={question.id}>
          <td></td>
          <td>Варианты ответов не найдены</td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
      )}
    </>
  );
};

export default QuestionRowEdit;
