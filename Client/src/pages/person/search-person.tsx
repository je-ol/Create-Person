import React, { useState } from "react";
import { Card } from "@/components/ui/card";
import searchPoster from "@/assets/search-poster.jpg";
import blueEllipse from "@/assets/Ellipse-blue.png";
import CardCover from "@/components/person/card-cover";
import CardForm from "@/components/person/card-form";

import SearchPersonForm from "./partials/form/search-person-form";

export function SearchPerson() {
  const [open, setOpen] = useState<boolean>(false);
 
  return (
    <Card variant="right" className="relative">
      {!open ? (
        <div
          className="w-full h-full flex justify-center items-center z-10"
          onClick={() => setOpen(true)}
        >
          <CardCover coverImage={searchPoster} header={"Search"} />
        </div>
      ) : (
        <div className="w-full h-full flex justify-center items-center z-10">
          <CardForm
            title={"Search for a person"}
            description={
              "Introduce an ID and find the person that matches it by clicking the Search button."
            }
            Form={<SearchPersonForm />}
          />
        </div>
      )}
      <img src={blueEllipse} alt="" className="absolute top-[20%] left-[34%]" />
    </Card>
  );
}

export default SearchPerson;
