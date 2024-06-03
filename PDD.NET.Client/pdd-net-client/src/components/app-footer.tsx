import React from "react";
import { Container, Row, Col } from "react-bootstrap";

const AppFooter: React.FC = () => {
  return (
    <footer className="bg-light text-dark py-3">
      <Container>
        <Row>
          <Col className="text-center">
            &copy; {new Date().getFullYear()} Orange
          </Col>
        </Row>
      </Container>
    </footer>
  );
};

export default AppFooter;
