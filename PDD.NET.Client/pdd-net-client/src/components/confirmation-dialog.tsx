import React from "react";
import { IConfirmationDialog } from "../types/types";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import { useAppSelector } from "../services/hooks";
import {
  getDeletingAnswerOption,
  getDeletingQuestion,
} from "../services/modal/selectors";

const ConfirmationDialog: React.FC<IConfirmationDialog> = ({
  title,
  body,
  onApproveClick,
  onRejectClick,
  show,
  onHide,
}) => {
  const deletingQuestion = useAppSelector(getDeletingQuestion);
  const deletingAnswerOption = useAppSelector(getDeletingAnswerOption);

  return (
    <Modal
      show={show}
      onHide={onHide}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">{title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>
          {body} Текст элемента:{" "}
          {deletingQuestion?.text || deletingAnswerOption?.text}
        </p>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onRejectClick}>
          Нет
        </Button>
        <Button variant="primary" onClick={onApproveClick}>
          Да
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ConfirmationDialog;
