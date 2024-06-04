import React, { useState, FormEvent } from "react";
import { Form, Button, Container } from "react-bootstrap";
import { useForm } from "../hooks/use-form";
import { IResetPasswordRequest } from "../types/types";

const ResetPasswordPage: React.FC = () => {
  const { formState, handleFieldChange } = useForm<IResetPasswordRequest>({
    password: "",
    confirmPassword: "",
  });

  const [validated, setValidated] = useState(false);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const form = e.currentTarget;
    if (
      !form.checkValidity() ||
      formState.password !== formState.confirmPassword
    ) {
      e.stopPropagation();
    } else {
      console.log("Form data:", formState);
    }
    setValidated(true);
  };

  return (
    <Container className="mt-5 d-flex flex-column align-items-center">
      <h1 className="mb-4">Сброс пароля</h1>
      <Form
        noValidate
        validated={validated}
        onSubmit={handleSubmit}
        className="w-50"
      >
        <Form.Group controlId="formPassword" className="mb-3">
          <Form.Control
            required
            type="password"
            name="password"
            value={formState.password}
            onChange={handleFieldChange}
            placeholder="Пароль"
          />
          <Form.Control.Feedback type="invalid">
            Пожалуйста, введите пароль.
          </Form.Control.Feedback>
        </Form.Group>

        <Form.Group controlId="formConfirmPassword" className="mb-3">
          <Form.Control
            required
            type="password"
            name="confirmPassword"
            value={formState.confirmPassword}
            onChange={handleFieldChange}
            placeholder="Подтвердите пароль"
            isInvalid={formState.password !== formState.confirmPassword}
          />
          <Form.Control.Feedback type="invalid">
            Пароли не совпадают.
          </Form.Control.Feedback>
        </Form.Group>
        <div className="d-flex justify-content-center">
          <Button variant="primary" type="submit">
            Подтвердить
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default ResetPasswordPage;
