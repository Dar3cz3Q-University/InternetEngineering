import { useDashboardSearch } from "@/components/contexts/DashboardSearchContext";
import SearchResultListItem from "./SearchResultListItem";
import Fuse from "fuse.js";
import React from "react"
import { useQuery } from "@tanstack/react-query";
import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import getRestaurantsRequest from "./_queries/GetRestaurantsQuery";

const SearchResultList = () => {
    const { searchValue, selectedCategoryIDs } = useDashboardSearch();
    const { currentLocation } = useCurrentLocation();

    const { data = [] } = useQuery({
        queryKey: [selectedCategoryIDs, currentLocation?.id],
        queryFn: () => getRestaurantsRequest(
            selectedCategoryIDs,
            currentLocation?.latitude,
            currentLocation?.longitude
        ),
        refetchOnMount: true
    });

    const fuse = new Fuse(data, {
        keys: ["name"],
        threshold: 0.4
    });

    const normalizedSearchValue = searchValue ?? "";
    const filteredRestaurants = fuse.search(normalizedSearchValue).map(result => result.item);

    return (
        <div className="w-full flex flex-col mt-[24px] mb-[8px]">
            <p className="font-bold text-lg mb-[8px]">Results</p>
            {
                filteredRestaurants.length > 0 ? (
                    <div className="flex flex-col gap-[32px]">
                        {filteredRestaurants.map(restaurant => (
                            <SearchResultListItem
                                key={restaurant.id}
                                restaurantData={restaurant}
                            />
                        ))}
                    </div>
                ) : (
                    <div className="w-full flex flex-row justify-center">
                        <p className="text-lg opacity-70">No results found.</p>
                    </div>
                )
            }
        </div>
    )
}

export default SearchResultList;
