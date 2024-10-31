import { useContext, useEffect, useState } from "react";
import { Input } from "../../../components/ui/input";
import bgVector from "@/assets/Bg-vector-Create.png";
import copy from "@/assets/copy.svg";
import { PersonContext } from "@/context/personContext";
import { useToast } from "@/hooks/use-toast";
import { BadgeCheck } from "lucide-react";


export default function CreateResult() {
  const { toast } = useToast();
  const { isCreated, resultId, personForm } = useContext(PersonContext);
  const [inputValue, setInputValue] = useState<number | null>(resultId);

    useEffect(() => {
      setInputValue(resultId);
    }, [resultId]);

  const copyId = () => {
    navigator.clipboard.writeText(resultId !== null ? resultId.toString() : "");
    toast({
      variant: "success",
      action: (
        <div className="flex items-center justify-center">
          <BadgeCheck className="mr-4 text-success-bright" />
          <div className="flex flex-col">
            <p className="text-md font-semibold">Success!</p>
            <p className="text-sm font-normal text-off-white-dark">ID was added to your clipboard</p>
          </div>
        </div>
      ),
    });
  }

  return (
    <>
      <div className="w-full h-[33.8%] flex justify-center items-center relative">
        <img src={bgVector} alt="" className="h-[96%] absolute top-0 right-0" />
        {isCreated && (
          <div className="max-w-[85%]">
            <p className="font-bold text-xl mb-4">
              The person "{personForm?.firstName} {personForm?.lastName}” has been successfully created.
              <br />
              The assigned ID is:
            </p>
            <div className="min-w-[90%] relative">
              <Input
                id="id"
                value={inputValue?.toString()}
              />
              <img
                src={copy}
                alt="Copy Icon"
                className="absolute right-5 top-1/2 transform -translate-y-1/2 cursor-pointer"
                onClick={() => copyId()}
              />
            </div>
          </div>
        )}
      </div>
    </>
  );
}
