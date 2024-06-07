import React, { FormEvent, useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { useForm } from "../hooks/use-form";
import { IRestorePasswordRequest } from "../types/types";

const RestorePasswordPage: React.FC = () => {
  const { formState, handleFieldChange } = useForm<IRestorePasswordRequest>({
    email: "",
  });

  const [validated, setValidated] = useState(false);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const form = e.currentTarget;
    if (!form.checkValidity()) {
      e.stopPropagation();
    } else {
      console.log("Form data:", formState);
    }
    setValidated(true);
  };

  return (
    <Container className="mt-5 d-flex flex-column align-items-center">
      <h1 className="mb-4">Восстановление пароля</h1>
      <Form
        noValidate
        validated={validated}
        onSubmit={handleSubmit}
        className="w-50"
      >
        <Form.Group controlId="formEmail" className="mb-3">
          <Form.Control
            required
            type="email"
            name="email"
            value={formState.email}
            onChange={handleFieldChange}
            placeholder="Введите email от учетной записи"
          />
          <Form.Control.Feedback type="invalid">
            Пожалуйста, введите корректный email.
          </Form.Control.Feedback>
        </Form.Group>

        <div className="d-flex justify-content-center mb-3">
          <Button variant="primary" type="submit">
            Выслать письмо
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default RestorePasswordPage;
