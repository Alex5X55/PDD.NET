import React from "react";
import { useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { getCurrentQuestions } from "../services/question/selectors";
import Card from "react-bootstrap/Card";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import { setNextQuestion, setPrevQuestion } from "../services/question/reducer";

const QuestionCard: React.FC = () => {
  const { questionId } = useParams<{ questionId: string }>();
  const questionIdNumber = parseInt(questionId || "", 10);

  const currentQuestions = useAppSelector(getCurrentQuestions);

  const question = currentQuestions.find(
    (question) => question.id === questionIdNumber,
  );

  const dispatch = useAppDispatch();
  //TODO: переход должен сохранять форму
  const onNextQuestionHandleClick = () => {
    dispatch(setNextQuestion());
  };

  const onPrevQuestionHandleClick = () => {
    dispatch(setPrevQuestion());
  };

  return (
    <div className="container mb-3">
      <Card className="mt-4">
        {question?.imageData && (
          <img src={question.imageData} alt={question.text} />
        )}
        <Card.Body>
          <Card.Text>{question?.text}</Card.Text>
          <Form>
            <div className="mb-3">
              {question?.answerOptions.map((option) => (
                <Form.Check
                  key={option.id}
                  type={"radio"}
                  id={`answer-${option.id}`}
                  name="answer"
                  label={option.text}
                />
              ))}
            </div>
          </Form>
          <div className="d-flex justify-content-between mt-4">
            <Button variant="primary" onClick={onPrevQuestionHandleClick}>
              Предыдущий вопрос
            </Button>
            <Button variant="primary" onClick={onNextQuestionHandleClick}>
              Следующий вопрос
            </Button>
          </div>
        </Card.Body>
      </Card>
    </div>
  );
};

export default QuestionCard;
