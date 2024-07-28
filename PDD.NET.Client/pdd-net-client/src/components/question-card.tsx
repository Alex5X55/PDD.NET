import React, { useEffect, useMemo } from "react";
import { useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { getCurrentQuestions } from "../services/question/selectors";
import Card from "react-bootstrap/Card";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import {
  resetCurrentQuestionNumber,
  setCurrentQuestionNumber,
  setNextQuestion,
  setPrevQuestion,
} from "../services/question/reducer";
import { getCurrentAnswers } from "../services/answer/selectors";
import { addCurrentAnswer } from "../services/answer/reducer";

const QuestionCard: React.FC = () => {
  const currentPath = window.location.pathname;
  const isExam = useMemo(
    () => currentPath.indexOf("exam") !== -1,
    [currentPath],
  );

  const dispatch = useAppDispatch();
  const currentQuestions = useAppSelector(getCurrentQuestions);
  const currentAnswers = useAppSelector(getCurrentAnswers);

  const { questionId } = useParams<{ questionId: string }>();
  const questionIdNumber = parseInt(questionId || "", 10);
  const question = useMemo(
    () => currentQuestions.find((item) => item.id === questionIdNumber),
    [questionIdNumber, currentQuestions],
  );

  const selectedAnswer = useMemo(
    () => currentAnswers.find((item) => item.questionId === question?.id),
    [currentAnswers, question],
  );

  useEffect(() => {
    if (question && currentQuestions.length > 0) {
      dispatch(setCurrentQuestionNumber(question));
    }

    return () => {
      dispatch(resetCurrentQuestionNumber());
    };
  }, [dispatch, question, currentQuestions]);

  const handleAnswerChange = (optionId: number, isRight: boolean) => {
    dispatch(
      addCurrentAnswer({
        answerId: optionId,
        questionId: questionIdNumber,
        isRight: isRight,
      }),
    );
  };

  const onNextQuestionHandleClick = () => {
    dispatch(setNextQuestion());
  };

  const onPrevQuestionHandleClick = () => {
    dispatch(setPrevQuestion());
  };

  return (
    <div className="container mb-3">
      {question ? (
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
                    checked={selectedAnswer?.answerId === option.id}
                    disabled={selectedAnswer !== undefined}
                    onChange={() =>
                      handleAnswerChange(option.id, option.isRight)
                    }
                    style={{
                      color: !isExam
                        ? selectedAnswer && option.isRight
                          ? "green"
                          : selectedAnswer &&
                              selectedAnswer.answerId === option.id
                            ? "red"
                            : "inherit"
                        : "",
                    }}
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
      ) : (
        <div>Вопрос не найден</div>
      )}
    </div>
  );
};

export default QuestionCard;
