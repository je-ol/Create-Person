import CreatePerson from "@/pages/person/create-person";
import CreateResult from "@/pages/person/partials/create-result";
import SearchPerson from "@/pages/person/search-person";
import SearchResult from "@/pages/person/partials/search-result";

function MainPage() {
  return (
    // main container
    <div className="w-5/6 h-5/6 flex">
      {/* left side */}
      <div className="w-1/2 p-2 flex flex-col justify-between">
        {/* top left component */}
        <CreatePerson />
        {/* bottom left component */}
        <SearchResult />
      </div>

      {/* right side */}
      <div className="w-1/2 p-2 flex flex-col justify-between">
        {/* top right component */}
        <CreateResult />
        {/* bottom right component */}
        <SearchPerson />
      </div>
    </div>
  );
}

export default MainPage;
