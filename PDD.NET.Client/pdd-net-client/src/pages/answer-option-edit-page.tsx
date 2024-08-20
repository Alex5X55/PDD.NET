import React, { useEffect, useMemo, useState } from "react";
import Card from "react-bootstrap/Card";
import Form from "react-bootstrap/Form";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { useNavigate, useParams } from "react-router-dom";
import { getAllQuestions } from "../services/question/selectors";
import { loadAllQuestions } from "../services/question/actions";
import { Button } from "react-bootstrap";
import {
  createAnswerOptionError,
  createAnswerOptionLoading,
  getNewAnswerOption,
} from "../services/answer-option/selectors";
import Preloader from "../components/preloader/preloader";
import { createAnswerOption } from "../services/answer-option/actions";
import { resetAnswerOptionState } from "../services/answer-option/reducer";

const AnswerOptionEditPage: React.FC = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const { answerOptionId } = useParams<{ answerOptionId: string }>();
  const answerOptionIdNumber = parseInt(answerOptionId || "", 10);

  const allQuestions = useAppSelector(getAllQuestions);

  const question = useMemo(
    () =>
      allQuestions.find((item) =>
        item.answerOptions.find(
          (answerOption) => answerOption.id === answerOptionIdNumber,
        ),
      ),
    [answerOptionIdNumber, allQuestions],
  );

  const answerOption = useMemo(
    () =>
      question?.answerOptions.find(
        (option) => option.id === answerOptionIdNumber,
      ),
    [answerOptionIdNumber, question],
  );

  const [isNewRecord, setIsNewRecord] = useState(true);
  const [text, setText] = useState(answerOption?.text || "");
  const [isRight, setIsRight] = useState(answerOption?.isRight || false);
  const [questionId, setQuestionId] = useState(answerOption?.questionId || 0);

  useEffect(() => {
    if (allQuestions.length === 0) {
      dispatch(loadAllQuestions());
    }
  }, [dispatch, allQuestions]);

  useEffect(() => {
    if (answerOption) {
      setIsNewRecord(false);
      setText(answerOption.text);
      setIsRight(answerOption.isRight);
      setQuestionId(answerOption?.questionId || 0);
    }
  }, [answerOption]);

  const handleTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setText(e.target.value);
  };

  const handleIsRightChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setIsRight(e.target.checked);
  };

  const handleQuestionChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setQuestionId(parseInt(e.target.value || "", 10) || 0);
  };

  const isLoading = useAppSelector(createAnswerOptionLoading);
  const error = useAppSelector(createAnswerOptionError);
  const newAnswerOption = useAppSelector(getNewAnswerOption);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (isNewRecord) {
      await dispatch(
        createAnswerOption({
          text: text,
          questionId: questionId,
          isRight: isRight,
        }),
      );
    }
  };

  useEffect(() => {
    if (newAnswerOption) {
      dispatch(loadAllQuestions());
      dispatch(resetAnswerOptionState());
      navigate(`/admin/questions`);
    }
  }, [newAnswerOption]);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">
          {isNewRecord ? "Создание" : "Редактирование"} варианта ответа
        </h1>
      </header>
      <p className="lead">
        На этой странице вы можете{" "}
        {isNewRecord
          ? "создать новый вариант ответа."
          : "редактировать параметры варианта ответа."}
      </p>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      <div className="container mb-3">
        <Card className="mt-4">
          <Card.Body>
            <Form onSubmit={handleSubmit}>
              <Form.Group className="mb-3">
                <Form.Label>Текст ответа</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Текст ответа"
                  value={text}
                  onChange={handleTextChange}
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Check
                  type="checkbox"
                  label="Правильный ответ"
                  checked={isRight}
                  onChange={handleIsRightChange}
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Вопрос</Form.Label>
                <Form.Select value={questionId} onChange={handleQuestionChange}>
                  {allQuestions?.map((questionItem) => (
                    <option key={questionItem.id} value={questionItem.id}>
                      {questionItem.text}
                    </option>
                  ))}
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

export default AnswerOptionEditPage;
