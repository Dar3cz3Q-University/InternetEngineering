import { OrderDetailsType } from "@/types/order/OrderDetailsType";
import apiRequest from "@/utils/api/api";

const getOrderDetailsRequest = async (orderId: string): Promise<OrderDetailsType> => apiRequest({
    method: "GET",
    url: `/orders/${orderId}`
});

export default getOrderDetailsRequest;
