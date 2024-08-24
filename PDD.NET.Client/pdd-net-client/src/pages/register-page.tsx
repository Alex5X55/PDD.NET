import React, { useState, FormEvent } from "react";
import { Form, Button, Container } from "react-bootstrap";
import { IRegisterForm } from "../types/types";
import { useForm } from "../hooks/use-form";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { register } from "../services/auth/actions";
import {
  getRegisterError,
  getRegisterLoading,
  getRegisterResponse,
} from "../services/auth/selectors";
import Preloader from "../components/preloader/preloader";
import { Navigate } from "react-router-dom";
import { resetRegisterState } from "../services/auth/reducer";

const RegisterPage: React.FC = () => {
  const dispatch = useAppDispatch();

  const { formState, handleFieldChange } = useForm<IRegisterForm>({
    login: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [validated, setValidated] = useState(false);

  const isRegisterLoading = useAppSelector(getRegisterLoading);
  const registerError = useAppSelector(getRegisterError);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    dispatch(resetRegisterState());
    e.preventDefault();
    const form = e.currentTarget;
    if (
      !form.checkValidity() ||
      formState.password !== formState.confirmPassword
    ) {
      e.stopPropagation();
    } else {
      dispatch(
        register({
          login: formState.login,
          email: formState.email,
          password: formState.password,
        }),
      );
    }
    setValidated(true);
  };

  const registerResponse = useAppSelector(getRegisterResponse);
  if (registerResponse?.login) {
    return <Navigate to="/login" />;
  }

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
      {isRegisterLoading && <Preloader />}
      {registerError && (
        <h1 className="display-4 mb-4">Ошибка: {registerError}</h1>
      )}
    </Container>
  );
};

export default RegisterPage;
