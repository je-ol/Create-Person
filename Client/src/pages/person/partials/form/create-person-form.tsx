import { useContext } from "react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useState } from "react";
import { useToast } from "@/hooks/use-toast";
import { BadgeCheck } from "lucide-react";
import { PersonContext } from "@/context/personContext";
import { Label } from "@/components/ui/label";
import { useCreatePersonMutation } from "@/features/api/apiSlice";


const CreatePersonForm = () => {
  const { toast } = useToast();
  const [firstname, setFirstname] = useState<string>("");
  const [lastname, setLastname] = useState<string>("");
  const { setIsCreated, setResultId, setPersonForm } = useContext(PersonContext);
  const [createPerson] = useCreatePersonMutation();

  const personForm = {
    firstName: firstname,
    lastName: lastname,
  };

  const handleCreate = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const responseId = await createPerson(personForm);
    console.log(responseId);

    if (responseId.data) {
      setPersonForm(personForm);
          setResultId(responseId.data.id);
          setIsCreated(true);

          toast({
            variant: "success",
            action: (
              <div className="flex items-center justify-center">
                <BadgeCheck className="mr-4 text-success-bright" />
                <div className="flex flex-col">
                  <p className="text-md font-semibold">Success!</p>
                  <p className="text-sm font-normal text-off-white-dark">
                    Your data has been saved!
                  </p>
                </div>
              </div>
            ),
          });
    } else if (responseId.error) {
      toast({
        variant: "error",
        action: (
          <div className="flex items-center justify-center">
            <BadgeCheck className="mr-4 text-error-bright" />
            <div className="flex flex-col">
              <p className="text-md font-semibold">Error!</p>
              <p className="text-sm font-normal text-off-white-dark">
                {responseId.error.data[0] }
              </p>
            </div>
          </div>
        ),
      });
    }
    
  };

  return (
    <form onSubmit={handleCreate}>
      <div className="flex flex-col gap-5 ">
        <div className="flex flex-col gap-3">
          <Label htmlFor="name">First Name</Label>
          <Input
            name="name"
            value={firstname}
            placeholder="John"
            onChange={(e) => {
              setFirstname(e.target.value);
            }}
          />
        </div>
        <div className="flex flex-col gap-3">
          <Label htmlFor="name">Last Name</Label>
          <Input
            name="name"
            value={lastname}
            placeholder="Doe"
            onChange={(e) => {
              setLastname(e.target.value);
            }}
          />
        </div>
      </div>
      <Button variant="blue" size="md" type="submit">
        Create
      </Button>
    </form>
  );
};

export default CreatePersonForm;