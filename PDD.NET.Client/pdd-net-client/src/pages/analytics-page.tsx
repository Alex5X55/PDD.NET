import React, { useEffect } from "react";
import {
  getAnalyticsDataError,
  getAnalyticsDataLoading,
  getAnalyticsDataResponse,
} from "../services/analytics/selectors";
import { useAppDispatch, useAppSelector } from "../services/hooks";
import Preloader from "../components/preloader/preloader";
import { getAnalyticsData } from "../services/analytics/actions";
import { format } from "date-fns";

const AnalyticsPage: React.FC = () => {
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(getAnalyticsData());
  }, [dispatch]);

  const analytics = useAppSelector(getAnalyticsDataResponse);
  const isLoading = useAppSelector(getAnalyticsDataLoading);
  const error = useAppSelector(getAnalyticsDataError);

  return (
    <div className="container">
      <header className="jumbotron mt-5">
        <h1 className="display-4 mb-4">Аналитика</h1>
      </header>
      <p className="lead">
        В этом разделе вы можете увидеть аналитику прохождения экзамена по
        пользователям.
      </p>
      {isLoading && <Preloader />}
      {error && <h1 className="display-4 mb-4">Ошибка: {error}</h1>}
      {analytics.length > 0 ? (
        <table className="table table-striped">
          <thead>
            <tr key={"thead"}>
              <th scope="col">Дата</th>
              <th scope="col">Логин</th>
              <th scope="col">Успешность прохождения</th>
            </tr>
          </thead>
          <tbody>
            {analytics.map((item) => (
              <tr key={item.login + item.createdOn}>
                <td>
                  {format(new Date(item.createdOn), "dd.MM.yyyy HH:mm:ss")}
                </td>
                <td>
                  <b>{item.login}</b>
                </td>
                <td>{item.isSuccess ? "Да" : "Нет"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <div>Данные по аналитике не найдены</div>
      )}
    </div>
  );
};

export default AnalyticsPage;
