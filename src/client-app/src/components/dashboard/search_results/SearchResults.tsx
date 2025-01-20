import SearchResultList from "./SearchResultList";
import ToogleCategories from "./ToggleCategories";

const SearchResults = () => {
    return (
        <div className="w-full p-[24px] font-roboto">
            <ToogleCategories />
            <SearchResultList />
        </div>
    )
}

export default SearchResults;