import React from "react";
import { IQuestionList } from "../types/types";
import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import CustomNavLink from "./custom-nav-link/custom-nav-link";

const QuestionNumberList: React.FC<IQuestionList> = ({ questions }) => {
  return (
    <div className="container">
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              {questions.map((item, index) => (
                <Nav.Link as={CustomNavLink} to={`${item.id}`} key={item.id}>
                  {index + 1}
                </Nav.Link>
              ))}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </div>
  );
};

export default QuestionNumberList;
