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
        <p className="lead">
          {/*TODO: ссылка на будущий раздел*/}
          Пройти экзамен по ПДД: Наш сайт предлагает обширную базу вопросов,
          идентичных тем, что вы встретите на реальном экзамене. Тренируйтесь с
          нашими интерактивными тестами и повышайте свои шансы на успешное
          прохождение экзамена.
        </p>
        <p className="lead">
          {/*TODO: ссылка на будущий раздел*/}
          Вопросы по темам ПДД: Отвечайте на вопросы из той категории, которая
          вас интересует (дорожные знаки, разметка, правила проезда
          перекрёстков, первая помощь и т.д.).
        </p>
        <p className="lead">
          {/*TODO: ссылка на будущий раздел*/}
          Билеты списком: 40 билетов ПДД из категория A и B.
        </p>
      </header>
    </div>
  );
}
