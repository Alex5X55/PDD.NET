import { ChangeEvent, useState } from "react";

export const useForm = <T extends Record<string, any>>(initialState: T) => {
  const [formState, setFormState] = useState<T>(initialState);

  const handleFieldChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFormState({ ...formState, [e.target.name]: e.target.value });
  };

  return {
    formState,
    handleFieldChange,
    setFormState,
  };
};
