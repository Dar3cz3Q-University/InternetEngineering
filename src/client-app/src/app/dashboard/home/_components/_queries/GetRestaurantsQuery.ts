import { RestaurantType } from "@/types/restaurant/RestaurantType";
import apiRequest from "@/utils/api/api";

const getRestaurantsRequest = async (
    categoryId: string,
    lat?: number,
    lng?: number,
): Promise<RestaurantType[]> => apiRequest({
    method: "GET",
    url: "/restaurants",
    params: {
        latitude: lat,
        longitude: lng,
        categories: [categoryId]
    }
});

export default getRestaurantsRequest;
