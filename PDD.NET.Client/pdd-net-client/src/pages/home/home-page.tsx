import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";

export default function HomePage() {
  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Главная страница</h1>
        <p className="lead">
          Добро пожаловать на портал PDD.NET, ваш надёжный помощник в подготовке
          к сдаче экзаменов по правилам дорожного движения (ПДД). Здесь вы
          сможете:
        </p>
        <Card className="mb-4">
          <Card.Body>
            <Card.Title>Пройти экзамен по ПДД</Card.Title>
            <Card.Text>
              Наш сайт предлагает обширную базу вопросов, идентичных тем, что вы
              встретите на реальном экзамене. Тренируйтесь с нашими
              интерактивными тестами и повышайте свои шансы на успешное
              прохождение экзамена.
            </Card.Text>
            {/*TODO: ссылка на будущий раздел*/}
            <Button variant="primary">Перейти в раздел</Button>
          </Card.Body>
        </Card>
        <Card className="mb-4">
          <Card.Body>
            <Card.Title>Вопросы по темам ПДД</Card.Title>
            <Card.Text>
              Отвечайте на вопросы из той категории, которая вас интересует
              (дорожные знаки, разметка, правила проезда перекрёстков, первая
              помощь и т.д.).
            </Card.Text>
            {/*TODO: ссылка на будущий раздел*/}
            <Button variant="primary">Перейти в раздел</Button>
          </Card.Body>
        </Card>
        <Card className="mb-4">
          <Card.Body>
            <Card.Title>Билеты списком</Card.Title>
            <Card.Text>40 билетов ПДД из категория A и B.</Card.Text>
            {/*TODO: ссылка на будущий раздел*/}
            <Button variant="primary">Перейти в раздел</Button>
          </Card.Body>
        </Card>
      </header>
    </div>
  );
}
