import React, { useState, ChangeEvent, FormEvent } from "react";
import { Form, Button, Container } from "react-bootstrap";

interface FormData {
  login: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const RegisterPage: React.FC = () => {
  const [formData, setFormData] = useState<FormData>({
    login: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [validated, setValidated] = useState(false);

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const form = e.currentTarget;
    if (
      !form.checkValidity() ||
      formData.password !== formData.confirmPassword
    ) {
      e.stopPropagation();
    } else {
      console.log("Form data:", formData);
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
            value={formData.login}
            onChange={handleChange}
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
            value={formData.email}
            onChange={handleChange}
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
            value={formData.password}
            onChange={handleChange}
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
            value={formData.confirmPassword}
            onChange={handleChange}
            placeholder="Подтвердите пароль"
            isInvalid={formData.password !== formData.confirmPassword}
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
