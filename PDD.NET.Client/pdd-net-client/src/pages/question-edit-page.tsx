import React, { useEffect, useMemo } from "react";
import Card from "react-bootstrap/Card";
import Form from "react-bootstrap/Form";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { getAllQuestions } from "../services/question/selectors";
import { useParams } from "react-router-dom";
import { loadAllQuestions } from "../services/question/actions";
import { getQuestionCategories } from "../services/question-category/selectors";
import { loadQuestionCategories } from "../services/question-category/actions";
import { Button } from "react-bootstrap";

const QuestionEditPage: React.FC = () => {
  const dispatch = useAppDispatch();
  const allQuestions = useAppSelector(getAllQuestions);
  const allQuestionCategories = useAppSelector(getQuestionCategories);

  useEffect(() => {
    if (allQuestions.length === 0) dispatch(loadAllQuestions());
    if (allQuestionCategories.length === 0) dispatch(loadQuestionCategories());
  }, [dispatch]);

  const { questionId } = useParams<{ questionId: string }>();
  const questionIdNumber = parseInt(questionId || "", 10);
  const question = useMemo(
    () => allQuestions.find((item) => item.id === questionIdNumber),
    [questionIdNumber, allQuestions],
  );

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Редактирование вопроса</h1>
      </header>
      <p className="lead">
        На этой странице вы можете редактировать параметры вопроса.
      </p>
      <div className="container mb-3">
        <Card className="mt-4">
          {question?.imageData && (
            <img src={question.imageData} alt={question.text} />
          )}
          <Card.Body>
            <Card.Text>{question?.text}</Card.Text>
            <Form>
              <Form.Group className="mb-3">
                <Form.Label>Текст вопроса</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Текст вопроса"
                  defaultValue={question?.text}
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Ссылка на изображение</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Ссылка на изображение"
                  defaultValue={question?.imageData}
                />
              </Form.Group>
              <Form.Group controlId="formFile" className="mb-3">
                <Form.Label>Файл изображения</Form.Label>
                <Form.Control type="file" />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Категория вопроса</Form.Label>
                <Form.Select>
                  {allQuestionCategories?.map((category) =>
                    category.id === question?.category?.id ? (
                      <option selected key={category.id} value={category.id}>
                        {category.text}
                      </option>
                    ) : (
                      <option key={category.id} value={category.id}>
                        {category.text}
                      </option>
                    ),
                  )}
                </Form.Select>
              </Form.Group>
              <Button type="submit">Сохранить</Button>
            </Form>
          </Card.Body>
        </Card>
      </div>
    </div>
  );
};

export default QuestionEditPage;
