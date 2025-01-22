import { RestaurantType } from "@/types/restaurant/RestaurantType";
import apiRequest from "@/utils/api/api";

const getRestaurantsRequest = async (
  categoryIds: string[],
  lat?: number,
  lng?: number
): Promise<RestaurantType[]> => {
  const params: Record<string, any> = {
    latitude: lat,
    longitude: lng,
  };

  if (categoryIds.length > 0) {
    params.categories = categoryIds.join(",");
  }

  return apiRequest({
    method: "GET",
    url: "/restaurants",
    params,
  });
};

export default getRestaurantsRequest;
