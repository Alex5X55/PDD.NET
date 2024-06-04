import React from "react";
import { useParams } from "react-router-dom";
import { mockData } from "../data/mock-data";

const QuestionCard: React.FC = () => {
  const { questionId } = useParams<{ questionId: string }>();
  const questionIdNumber = parseInt(questionId || "", 10);
  const questionName = mockData.questions.find(
    (question) => question.id === questionIdNumber,
  )?.text;

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">{questionName}</h1>
      </header>
    </div>
  );
};

export default QuestionCard;
