import { useDashboardSearch } from "@/components/contexts/DashboardSearchContext";
import { RestaurantType } from "@/types/restaurant/RestaurantType";
import SearchResultListItem from "./SearchResultListItem";
import Fuse from "fuse.js";
import React from "react"

//DUMMY DATA FOR TESTS
const RESTAURANTS_DUMMY_DATA: Omit<RestaurantType, "description">[] = [
    { id: "81362e38-7560-40ba-9d7f-cdc388d13680", name: "McDonald's Makro", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "82362e38-7560-40ba-9d7f-cdc388d13680", name: "Burger King Szewska", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "83362e38-7560-40ba-9d7f-cdc388d13680", name: "Max Premium Burgers", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: false },
    { id: "84362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab King Bar", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "85362e38-7560-40ba-9d7f-cdc388d13680", name: "Surti Kebab", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "86362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab Pasja", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "87362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
]
//-----

const SearchResultList = () => {
    const {searchValue} = useDashboardSearch();

    const fuse = new Fuse(RESTAURANTS_DUMMY_DATA, {
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
                        {RESTAURANTS_DUMMY_DATA.map(restaurant => (
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