async function getResponse<T>(
  res: Response,
  handler: (data: any) => T,
): Promise<T> {
  const jsonData = await res.json();
  if (res.ok) {
    return handler(jsonData);
  }
  throw new Error(jsonData.message || `Ошибка ${res.status}`);
}

export default getResponse;
