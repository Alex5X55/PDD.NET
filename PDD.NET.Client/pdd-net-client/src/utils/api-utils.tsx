async function getResponse<T>(res: Response): Promise<T> {
  const jsonData = await res.json();
  if (res.ok) {
    return jsonData;
  }
  throw new Error(jsonData.message || `Ошибка ${res.status}`);
}

export default getResponse;
