import { ReactNode } from "react";
import {
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

interface Props {
  title: string;
  description: string;
  Form: ReactNode;
}

const CardForm = ({ title, description, Form }: Props) => {
  return (
    <div className="w-[99.8%] h-[99.7%] relative flex flex-col justify-center items-center bg-primary-light rounded-[16px]">
      <div className="w-[83%]">
        <CardHeader>
          <CardTitle>{title}</CardTitle>
          <CardDescription>{description}</CardDescription>
        </CardHeader>
        <CardContent className="space-y-2">{Form}</CardContent>

      </div>
    </div>
  );
};

export default CardForm;
