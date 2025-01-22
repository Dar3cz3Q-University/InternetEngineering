import { RestaurantDetailsType } from "@/types/restaurant/RestaurantDetailsType";
import apiRequest from "@/utils/api/api";

const getRestaurantDetailsRequest = async (
    restaurantId: string,
    lat?: number,
    lng?: number,
): Promise<RestaurantDetailsType> => apiRequest({
    method: "GET",
    url: `/restaurants/${restaurantId}`,
    params: {
        latitude: lat,
        longitude: lng,
    }
});

export default getRestaurantDetailsRequest;