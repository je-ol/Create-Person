import React from "react";
import bgVector from "@/assets/Bg-vector-Search.png";
import { PersonContext } from "@/context/personContext";


export default function SearchResult() {
  const { person, isSearched } = React.useContext(PersonContext);

  return (
    <div className="w-full h-[33.8%] flex justify-center items-center font-bold text-xl relative">
      <img
        src={bgVector}
        alt="Copy Icon"
        className="h-[96%] absolute bottom-0 left-0"
      />
      <div>
        {isSearched && (
          <p>
            The person you were looking for was found:
            <br />
            <br />
            First Name: "{person?.firstName}"
            <br />
            Last Name: "{person?.lastName}"
          </p>
        )}
      </div>
    </div>
  );
}
