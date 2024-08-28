async function getResponse<T>(res: Response): Promise<T> {
  let jsonData: T | undefined;

  // Проверка типа содержимого ответа
  const contentType = res.headers.get("content-type");

  if (contentType && contentType.includes("application/json")) {
    try {
      jsonData = await res.json();
    } catch (e) {
      throw new Error(`Ошибка при парсинге JSON: ${(e as Error).message}`);
    }
  } else {
    const textData = await res.text();
    throw new Error(`Неожиданный формат ответа: ${textData}`);
  }

  // Если ответ успешен, возвращаем данные
  if (res.ok && jsonData !== undefined) {
    return jsonData;
  }

  // Обработка ошибки, если ответ не ok
  const errorMessage =
    (jsonData as any)?.details?.[0] ??
    (jsonData as any)?.errors?.[0] ??
    (jsonData as any)?.message ??
    `Ошибка ${res.status}`;

  throw new Error(errorMessage);
}

export default getResponse;
