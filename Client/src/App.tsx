import "./App.css";
import { useState } from "react";
import MainPage from "./pages/MainPage";
import { Toaster } from "@/components/ui/toaster";
import { PersonContext } from "./context/personContext";
import { Person } from "./context/personContext";
import { PersonForm } from "./context/personContext";

function App() {
  const [isSearched, setIsSearched] = useState<boolean>(false);
  const [isCreated, setIsCreated] = useState<boolean>(false);
  const [person, setPerson] = useState<Person | null >(null);
  const [resultId, setResultId] = useState<number | null>(0);
  const [personForm, setPersonForm] = useState<PersonForm | null>(null);
  
  return (
    <>
      <PersonContext.Provider value={{isSearched, setIsSearched, isCreated, setIsCreated, person, setPerson, resultId, setResultId, personForm, setPersonForm}}>
        <MainPage />
        <Toaster />
      </PersonContext.Provider>
    </>
  );
}

export default App;
