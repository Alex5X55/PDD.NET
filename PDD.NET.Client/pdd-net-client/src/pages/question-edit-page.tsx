import React, { useEffect, useMemo, useState } from "react";
import Card from "react-bootstrap/Card";
import Form from "react-bootstrap/Form";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import {
  createQuestionError,
  createQuestionLoading,
  getAllQuestions,
  getNewQuestion,
} from "../services/question/selectors";
import { useNavigate, useParams } from "react-router-dom";
import { createQuestion, loadAllQuestions } from "../services/question/actions";
import { getQuestionCategories } from "../services/question-category/selectors";
import { loadQuestionCategories } from "../services/question-category/actions";
import { Button } from "react-bootstrap";
import Preloader from "../components/preloader/preloader";
import { resetQuestionState } from "../services/question/reducer";

const QuestionEditPage: React.FC = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const allQuestions = useAppSelector(getAllQuestions);
  const allQuestionCategories = useAppSelector(getQuestionCategories);

  const { questionId } = useParams<{ questionId: string }>();
  const questionIdNumber = parseInt(questionId || "", 10);

  const question = useMemo(
    () => allQuestions.find((item) => item.id === questionIdNumber),
    [questionIdNumber, allQuestions],
  );

  const [isNewRecord, setIsNewRecord] = useState(true);

  const [text, setText] = useState(question?.text || "");
  const [imageData, setImageData] = useState(question?.imageData || "");
  const [categoryId, setCategoryId] = useState(question?.category?.id || 0);
  const [imageFile, setImageFile] = useState<File | null>(null);

  useEffect(() => {
    if (allQuestions.length === 0) dispatch(loadAllQuestions());
    if (allQuestionCategories.length === 0) dispatch(loadQuestionCategories());
  }, [dispatch]);

  useEffect(() => {
    if (question) {
      setIsNewRecord(false);
      setText(question.text);
      setImageData(question.imageData);
      setCategoryId(question.category?.id || 0);
    }
  }, [question]);

  const handleTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setText(e.target.value);
  };

  const handleImageDataChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setImageData(e.target.value);
  };

  const handleCategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setCategoryId(parseInt(e.target.value || "", 10) || 0);
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files.length > 0) {
      setImageFile(e.target.files[0]);
    }
  };

  const isLoading = useAppSelector(createQuestionLoading);
  const error = useAppSelector(createQuestionError);
  const newQuestion = useAppSelector(getNewQuestion);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (isNewRecord) {
      await dispatch(
        createQuestion({
          text: text,
          imageData: imageData,
          categoryId: categoryId,
        }),
      );
    }
  };

  useEffect(() => {
    if (newQuestion) {
      dispatch(loadAllQuestions());
      dispatch(resetQuestionState());
      navigate(`/admin/questions`);
    }
  }, [newQuestion]);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">
          {isNewRecord ? "Создание" : "Редактирование"} вопроса
        </h1>
      </header>
      <p className="lead">
        На этой странице вы можете{" "}
        {isNewRecord ? "создать вопрос." : "редактировать параметры вопроса."}
      </p>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      <div className="container mb-3">
        <Card className="mt-4">
          {question?.imageData && (
            <img src={question.imageData} alt={question.text} />
          )}
          <Card.Body>
            <Card.Text>{question?.text}</Card.Text>
            <Form onSubmit={handleSubmit}>
              <Form.Group className="mb-3">
                <Form.Label>Текст вопроса</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Текст вопроса"
                  value={text}
                  onChange={handleTextChange}
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Ссылка на изображение</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Ссылка на изображение"
                  value={imageData}
                  onChange={handleImageDataChange}
                />
              </Form.Group>
              <Form.Group controlId="formFile" className="mb-3">
                <Form.Label>Файл изображения</Form.Label>
                <Form.Control type="file" onChange={handleFileChange} />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Категория вопроса</Form.Label>
                <Form.Select value={categoryId} onChange={handleCategoryChange}>
                  {allQuestionCategories?.map((category) => (
                    <option key={category.id} value={category.id}>
                      {category.text}
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

export default QuestionEditPage;
