import { NearbyOrderType } from "@/types/order/NearbyOrderType";
import apiRequest from "@/utils/api/api";

const nearbyOrderRequest = async (
    lat?: number,
    lng?: number,
): Promise<NearbyOrderType[]> => apiRequest({
    method: "GET",
    url: "/orders/ready-for-collection",
    params: {
        latitude: lat,
        longitude: lng
    }
});

export default nearbyOrderRequest;
