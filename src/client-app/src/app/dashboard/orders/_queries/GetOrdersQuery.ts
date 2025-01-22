import { OrderType } from "@/types/order/OrderType";
import apiRequest from "@/utils/api/api";

const getOrdersRequest = async (
    userID: string
): Promise<OrderType[]> => apiRequest({
    method: "GET",
    url: `/orders/${userID}`
});

export default getOrdersRequest;
