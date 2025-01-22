import { ActiveOrderType } from "@/types/order/ActiveOrderType";
import apiRequest from "@/utils/api/api";

const activeOrderRequest = async (): Promise<ActiveOrderType> => apiRequest({
    method: "GET",
    url: "/orders/active"
});

export default activeOrderRequest;
