import { OrderType } from "@/types/order/OrderType";
import apiRequest from "@/utils/api/api";

const getOrdersRequest = async (): Promise<OrderType[]> => apiRequest({
    method: "GET",
    url: "/orders"
});

export default getOrdersRequest;
