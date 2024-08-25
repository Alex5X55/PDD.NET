import React from "react";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";

const AdminPanelPage: React.FC = () => {
  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Админская панель</h1>
      </header>
      <p className="lead">
        В этом разделе вы можете редактировать разделы системы. А также
        просмотреть статистику.
      </p>
      <div className="d-grid gap-2">
        <Link to={`/admin/questions`}>
          <Button variant="primary" size="lg">
            Вопросы и варианты ответов
          </Button>
        </Link>
        <Link to={`/admin/question-categories`}>
          <Button variant="primary" size="lg">
            Категории вопросов
          </Button>
        </Link>
        <Link to={`/admin/analytics`}>
          <Button variant="primary" size="lg">
            Аналитика
          </Button>
        </Link>
      </div>
    </div>
  );
};

export default AdminPanelPage;
