import React from "react";
import { IConfirmationDialog } from "../types/types";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

const ConfirmationDialog: React.FC<IConfirmationDialog> = ({
  title,
  body,
  onApproveClick,
  onRejectClick,
  show,
  onHide,
}) => {
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
        <p>{body}</p>
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
