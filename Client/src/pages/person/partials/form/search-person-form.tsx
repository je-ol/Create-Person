import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useState } from "react";
import { useToast } from "@/hooks/use-toast";
import { BadgeCheck } from "lucide-react";
import { BadgeAlert } from 'lucide-react';
import { PersonContext } from "@/context/personContext";
import { useContext } from "react";
import { Label } from "@radix-ui/react-label";
import { useLazyGetPersonQuery } from "@/features/api/apiSlice";

const SearchPersonForm = () => {
  const { toast } = useToast();
  const [id, setId] = useState<string>("");
  const { setIsSearched, setPerson } = useContext(PersonContext);
  const [trigger] = useLazyGetPersonQuery();

  const handleSearch = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setIsSearched(true);

    const result = await trigger(id);
    if (result.isSuccess === true) {
      console.log(result);
      setPerson(result.data);
      toast({
        variant: "success",
        action: (
          <div className="flex items-center justify-center">
            <BadgeCheck className="mr-4 text-success-bright" />
            <div className="flex flex-col">
              <p className="text-md font-semibold">Success!</p>
              <p className="text-sm font-normal text-off-white-dark">
                Person was found!
              </p>
            </div>
          </div>
        ),
      });
      return;
    }
    else if (result.isError === true)
      console.log(result.error);
    {
      toast({
        variant: "error",
        action: (
          <div className="flex items-center justify-center">
            <BadgeAlert className="mr-4 text-error-bright" />
            <div className="flex flex-col">
              <p className="text-md font-semibold">Error!</p>
              <p className="text-sm font-normal text-off-white-dark">
                {if (result.status === 404) ? "Please enter an ID" : "A person with this ID was not found"} 
              </p>
            </div>
          </div>
        ),
      });
      return;
    }
  };

  return (
    <form onSubmit={handleSearch}>
      <div className="flex flex-col gap-3">
        <Label htmlFor="id">ID</Label>
        <Input
          name="id"
          value={id}
          placeholder="d704ac8c-7ff9-4ede-8d59-47d0d7ac44f0"
          onChange={(e) => {
            setId(e.target.value);
          }}
        />
      </div>
      <Button variant="blue" size="md" type="submit">
        Search
      </Button>
    </form>
  );
};

export default SearchPersonForm;
