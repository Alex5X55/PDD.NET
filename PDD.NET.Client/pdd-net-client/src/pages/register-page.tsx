import React, { useState, FormEvent } from "react";
import { Form, Button, Container } from "react-bootstrap";
import { IRegisterRequest } from "../types/types";
import { useForm } from "../hooks/use-form";

const RegisterPage: React.FC = () => {
  const { formState, handleFieldChange } = useForm<IRegisterRequest>({
    login: "",
    email: "",
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
      <h1 className="mb-4">Регистрация</h1>
      <Form
        noValidate
        validated={validated}
        onSubmit={handleSubmit}
        className="w-50"
      >
        <Form.Group controlId="formUsername" className="mb-3">
          <Form.Control
            required
            type="text"
            name="login"
            value={formState.login}
            onChange={handleFieldChange}
            placeholder="Логин"
          />
          <Form.Control.Feedback type="invalid">
            Пожалуйста, введите логин пользователя.
          </Form.Control.Feedback>
        </Form.Group>

        <Form.Group controlId="formEmail" className="mb-3">
          <Form.Control
            required
            type="email"
            name="email"
            value={formState.email}
            onChange={handleFieldChange}
            placeholder="Email"
          />
          <Form.Control.Feedback type="invalid">
            Пожалуйста, введите корректный email.
          </Form.Control.Feedback>
        </Form.Group>

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
            Регистрация
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default RegisterPage;
