import React, { useEffect, useMemo, useState } from "react";
import Card from "react-bootstrap/Card";
import Form from "react-bootstrap/Form";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "react-bootstrap";
import {
  createQuestionCategoryError,
  createQuestionCategoryLoading,
  getNewQuestionCategory,
  getQuestionCategories,
} from "../services/question-category/selectors";
import {
  createQuestionCategory,
  loadQuestionCategories,
} from "../services/question-category/actions";
import Preloader from "../components/preloader/preloader";
import {
  pushNewQuestionCategory,
  resetQuestionCategoryState,
} from "../services/question-category/reducer";

const QuestionCategoryEditPage: React.FC = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const { questionCategoryId } = useParams<{ questionCategoryId: string }>();
  const questionCategoryIdNumber = parseInt(questionCategoryId || "", 10);

  const allQuestionCategories = useAppSelector(getQuestionCategories);

  const questionCategory = useMemo(
    () =>
      allQuestionCategories.find(
        (item) => item.id === questionCategoryIdNumber,
      ),
    [questionCategoryIdNumber, allQuestionCategories],
  );

  const [isNewRecord, setIsNewRecord] = useState(true);
  const [text, setText] = useState(questionCategory?.text || "");

  useEffect(() => {
    dispatch(resetQuestionCategoryState());
    if (allQuestionCategories.length === 0) {
      dispatch(loadQuestionCategories());
    }
  }, [dispatch, allQuestionCategories]);

  useEffect(() => {
    if (questionCategory) {
      setIsNewRecord(false);
      setText(questionCategory.text);
    }
  }, [questionCategory]);

  const handleTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setText(e.target.value);
  };

  const isLoading = useAppSelector(createQuestionCategoryLoading);
  const error = useAppSelector(createQuestionCategoryError);
  const newQuestionCategory = useAppSelector(getNewQuestionCategory);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (isNewRecord) {
      await dispatch(createQuestionCategory({ text: text }));
    }
  };

  useEffect(() => {
    if (newQuestionCategory) {
      dispatch(pushNewQuestionCategory(newQuestionCategory));
      navigate(`/admin/question-categories`);
    }
  }, [newQuestionCategory]);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">
          {isNewRecord ? "Создание" : "Редактирование"} категории вопроса
        </h1>
      </header>
      <p className="lead">
        На этой странице вы можете{" "}
        {isNewRecord ? "создать новую категорию." : "редактировать категорию."}
      </p>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      <div className="container mb-3">
        <Card className="mt-4">
          <Card.Body>
            <Form onSubmit={handleSubmit}>
              <Form.Group className="mb-3">
                <Form.Label>Текст категории</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Текст категории"
                  value={text}
                  onChange={handleTextChange}
                />
              </Form.Group>
              <Button type="submit">Сохранить</Button>
            </Form>
          </Card.Body>
        </Card>
      </div>
    </div>
  );
};

export default QuestionCategoryEditPage;
