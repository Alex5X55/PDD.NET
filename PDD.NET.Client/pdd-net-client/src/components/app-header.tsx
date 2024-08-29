import React from "react";
import { NavLink } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { getUser } from "../services/auth/selectors";
import { Button } from "react-bootstrap";
import { resetUser } from "../services/auth/reducer";

export default function AppHeader() {
  const dispatch = useAppDispatch();

  const user = useAppSelector(getUser);
  const onLogoutHandler = () => {
    dispatch(resetUser());
  };

  return (
    <Navbar expand="lg" className="bg-body-tertiary">
      <Container>
        <Navbar.Brand>PDD.NET</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link as={NavLink} to="/" end>
              Главная
            </Nav.Link>
            <Nav.Link as={NavLink} to="/exam" end>
              Экзамен
            </Nav.Link>
            <Nav.Link as={NavLink} to="/question-categories" end>
              Вопросы по темам
            </Nav.Link>
          </Nav>
          <Nav className="ml-auto">
            {!user && (
              <Nav.Link as={NavLink} to="/login" end>
                Вход
              </Nav.Link>
            )}
            {!user && (
              <Nav.Link as={NavLink} to="/register" end>
                Регистрация
              </Nav.Link>
            )}
            {user?.role === "Admin" && (
              <Nav.Link as={NavLink} to="/admin" end>
                Админская панель
              </Nav.Link>
            )}
            {user && (
              <Nav.Link as={NavLink} to="/user-analytics" end>
                {user.name}
              </Nav.Link>
            )}
            {user && (
              <Button variant="light" size="sm" onClick={onLogoutHandler}>
                Выход
              </Button>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
