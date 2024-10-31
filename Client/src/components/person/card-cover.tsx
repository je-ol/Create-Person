type Props = {
  coverImage: string;
  header: string;
};

export default function CardCover({ coverImage, header }: Props) {
  return (
    <div className="w-[99.7%] h-[99.5%] relative rounded-[16px] overflow-hidden group cursor-pointer">
      <img
        src={coverImage}
        alt=""
        className="w-full h-full object-cover object-[0%_36%] rounded-[16px]"
      />
      <div className="absolute inset-0 bg-slate-950 opacity-0 group-hover:opacity-20 transition-opacity duration-300 rounded-[16px] " />
      <h2 className="absolute top-2/4 right-8 text-[60px] font-headline">
        {header}
      </h2>
    </div>
  );
}
