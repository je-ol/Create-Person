
import { createContext } from "react";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
}

export interface PersonForm {
  firstName: string;
  lastName: string;
}

interface PersonContextProps {
  isSearched: boolean;
  setIsSearched: (value: boolean) => void;
  isCreated: boolean;
  setIsCreated: (value: boolean) => void;
  person: Person | null;
  setPerson: (value: Person | null) => void;
  resultId: number | null;
  setResultId: (value: number | null) => void;
  personForm: PersonForm | null;
  setPersonForm: (value: PersonForm | null) => void;
}

export const PersonContext = createContext<PersonContextProps>({
  isSearched: false,
  setIsSearched: () => {},
  isCreated: false,
  setIsCreated: () => {},
  person: null,
  setPerson: () => {},
  resultId: null,
  setResultId: () => {},
  personForm: null,
  setPersonForm: () => {},
});
