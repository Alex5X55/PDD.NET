import React from "react";
import { IQuestionList } from "../types/types";
import { NavLink, useParams } from "react-router-dom";
import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";

const QuestionNumberList: React.FC<IQuestionList> = ({ questions }) => {
  const { categoryId } = useParams<{ categoryId: string }>();
  return (
    <div className="container">
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              {questions.map((item, index) => (
                <Nav.Link
                  as={NavLink}
                  to={`/question-category/${categoryId}/${item.id}`}
                  key={item.id}
                  end
                >
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
