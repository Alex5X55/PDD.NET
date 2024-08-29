import React, { FormEvent, useEffect, useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { useForm } from "../hooks/use-form";
import { ILoginRequest } from "../types/types";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { login } from "../services/auth/actions";
import {
  getLoginError,
  getLoginLoading,
  getLoginResponse,
} from "../services/auth/selectors";
import Preloader from "../components/preloader/preloader";
import { Navigate } from "react-router-dom";
import { resetLoginState } from "../services/auth/reducer";

const LoginPage: React.FC = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(resetLoginState());
  }, [dispatch]);

  const { formState, handleFieldChange } = useForm<ILoginRequest>({
    email: "",
    password: "",
  });

  const [validated, setValidated] = useState(false);

  const isLoginLoading = useAppSelector(getLoginLoading);
  const loginError = useAppSelector(getLoginError);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    dispatch(resetLoginState());
    e.preventDefault();
    const form = e.currentTarget;
    if (!form.checkValidity()) {
      e.stopPropagation();
    } else {
      dispatch(
        login({
          email: formState.email,
          password: formState.password,
        }),
      );
    }
    setValidated(true);
  };

  const loginResponse = useAppSelector(getLoginResponse);
  if (loginResponse?.success) {
    return <Navigate to="/" />;
  }

  return (
    <Container className="mt-5 d-flex flex-column align-items-center">
      <h1 className="mb-4">Вход</h1>
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

        <div className="d-flex justify-content-center mb-3">
          <Button variant="primary" type="submit">
            Вход
          </Button>
        </div>
      </Form>
      {isLoginLoading && <Preloader />}
      {loginError && <h1 className="display-4 mb-4">Ошибка: {loginError}</h1>}
    </Container>
  );
};

export default LoginPage;
