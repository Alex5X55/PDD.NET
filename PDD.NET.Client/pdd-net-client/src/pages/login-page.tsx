import React, { FormEvent, useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { Link } from "react-router-dom";
import { useForm } from "../hooks/use-form";
import { ILoginRequest } from "../types/types";

const LoginPage: React.FC = () => {
  const { formState, handleFieldChange } = useForm<ILoginRequest>({
    login: "",
    password: "",
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
      <h1 className="mb-4">Вход</h1>
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

        <div className="d-flex justify-content-center mb-3">
          <Button variant="primary" type="submit">
            Вход
          </Button>
        </div>
      </Form>
      <div className="d-flex justify-content-center">
        <Link to="/restore-password">Восстановить пароль</Link>
      </div>
    </Container>
  );
};

export default LoginPage;
