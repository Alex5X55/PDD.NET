import { IAnswerOption, IQuestion, IQuestionCategory } from "../types/types";

interface IMockData {
  categories: Array<IQuestionCategory>;
  questions: Array<IQuestion>;
  answerOptions: Array<IAnswerOption>;
}

export const mockData: IMockData = {
  categories: [
    { id: 1, text: "1 Общие положения" },
    { id: 2, text: "2 Обязанности водителей" },
    { id: 3, text: "3 Дорожные знаки" },
    { id: 4, text: "4 Дорожная разметка" },
    { id: 28, text: "28 Медицина" },
  ],
  questions: [
    {
      id: 101,
      categoryId: 1,
      imageData: "https://storage.yandexcloud.net/pddlife/abm/n33_1.jpg",
      text: "Какой маневр намеревается выполнить водитель легкового автомобиля?",
    },
    {
      id: 102,
      categoryId: 1,
      imageData: "https://storage.yandexcloud.net/pddlife/abm/n5_1.jpg",
      text: "Сколько проезжих частей имеет данная дорога?",
    },
    {
      id: 103,
      categoryId: 1,
      imageData: "https://storage.yandexcloud.net/pddlife/abm/n13_1.jpg",
      text: "Соответствуют ли действия водителя Правилам, если он движется посередине дороги?",
    },

    {
      id: 401,
      categoryId: 4,
      imageData: "https://storage.yandexcloud.net/pddlife/abm/n25_5.jpg",
      text: "Какой маневр Вам запрещается выполнить при наличии данной линии разметки?",
    },
    {
      id: 402,
      categoryId: 4,
      imageData: "https://storage.yandexcloud.net/pddlife/abm/n11_5.jpg",
      text: "Эта разметка, нанесенная на полосе движения:",
    },
    {
      id: 2801,
      categoryId: 28,
      imageData: "https://storage.yandexcloud.net/pddlife/no_picture.png",
      text: "В каких случаях следует начинать сердечно-легочную реанимацию пострадавшего?",
    },
  ],
  answerOptions: [
    {
      id: 1,
      questionId: 2801,
      text: "При наличии болей в области сердца и затрудненного дыхания.",
      isRight: false,
    },
    {
      id: 2,
      questionId: 2801,
      text: "При отсутствии у пострадавшего сознания, независимо от наличия дыхания.",
      isRight: false,
    },
    {
      id: 3,
      questionId: 2801,
      text: "При отсутствии у пострадавшего сознания, дыхания и кровообращения.",
      isRight: true,
    },
    { id: 4, questionId: 101, text: "Обгон.", isRight: false },
    {
      id: 5,
      questionId: 101,
      text: "Перестроение с дальнейшим опережением.",
      isRight: true,
    },
    { id: 6, questionId: 101, text: "Объезд.", isRight: false },
  ],
};
