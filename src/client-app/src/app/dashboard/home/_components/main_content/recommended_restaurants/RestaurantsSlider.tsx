import Restaurant from "./Restaurant";
import Carousel from "@/components/carousel/Carousel";
import { useQuery } from "@tanstack/react-query";
import getRestaurantsRequest from "../../_queries/GetRestaurantsQuery";
import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";

type PropType = {
    categoryID: string;
}

const RestaurantsSlider = (props: PropType) => {
    const { categoryID } = props;
    const { currentLocation } = useCurrentLocation();

    const { data } = useQuery({
        queryKey: ["restaurants", categoryID, currentLocation?.id],
        queryFn: () => getRestaurantsRequest(
            categoryID,
            currentLocation?.latitude,
            currentLocation?.longitude
        ),
        enabled: !!categoryID && !!currentLocation,
        refetchOnMount: true,
        refetchOnWindowFocus: false,
        staleTime: 0
    });

    return (
        <Carousel>
            {data && data.map(restaurant => (
                <Restaurant
                    key={restaurant.id}
                    restaurantData={restaurant}
                />
            ))}
        </Carousel>
    )
}

export default RestaurantsSlider;
