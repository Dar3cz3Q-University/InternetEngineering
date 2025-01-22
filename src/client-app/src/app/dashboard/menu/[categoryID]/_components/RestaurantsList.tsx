"use client";

import getRestaurantsRequest from "../_queries/GetRestaurantsQuery";
import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import ListSkeleton from "@/components/ui/skeletons/ListSkeleton";
import { useQuery } from "@tanstack/react-query";
import RestaurantsListItem from "./RestaurantsListItem";

type PropType = {
    categoryID: string;
}

const RestaurantsList = (props: PropType) => {
    const {categoryID} = props;
    const {currentLocation} = useCurrentLocation();
    
    const { data, isLoading } = useQuery({
        queryKey: [categoryID, currentLocation?.id],
        queryFn: () => getRestaurantsRequest(
            categoryID,
            currentLocation?.latitude,
            currentLocation?.longitude
        ),
    });

    return (
        <div className="w-full flex flex-col items-center gap-[32px]">
            {
            isLoading ? <ListSkeleton /> :
            data?.map(restaurant => (
                <RestaurantsListItem
                    key={restaurant.id}
                    restaurantData={restaurant}
                />
            ))
            }
        </div>
    )
}

export default RestaurantsList;