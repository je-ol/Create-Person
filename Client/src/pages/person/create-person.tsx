/* import { useCreatePersonMutation } from '../api/apiSlice'; */
import React, { useState } from "react";
import { Card } from "@/components/ui/card";
import createPoster from "@/assets/create-poster.jpg";
import pinkEllipse from "@/assets/Ellipse-pink.png";
import CardCover from "@/components/person/card-cover";
import CardForm from "@/components/person/card-form";
import CreatePersonForm from "./partials/form/create-person-form";

export function CreatePerson() {

  const [open, setOpen] = useState<boolean>(false);


  return (
    <>
      <Card variant="left" className="relative">
        {!open ? (
          <div
            className="w-full h-full flex justify-center items-center z-10"
            onClick={() => setOpen(true)}
          >
            <CardCover coverImage={createPoster} header={"Create"} />
          </div>
        ) : (
          <div className="w-full h-full flex justify-center items-center z-10 ">
            <CardForm
              title={"Create new person"}
              description={"Fill in the details below to create a new person."}
              Form={<CreatePersonForm/>}
            />
          </div>
        )}
      </Card>
      <img
        src={pinkEllipse}
        alt=""
        className="absolute top-[-100px] left-[-240px]"
      />
    </>
  );
}

export default CreatePerson;
