async function getResponse<T>(res: Response): Promise<T> {
  const jsonData = await res.json();
  if (res.ok) {
    return jsonData;
  }
  const errorMessage = jsonData.details
    ? jsonData.details[0]
    : jsonData.message
      ? jsonData.message
      : `Ошибка ${res.status}`;

  throw new Error(errorMessage);
}

export default getResponse;
