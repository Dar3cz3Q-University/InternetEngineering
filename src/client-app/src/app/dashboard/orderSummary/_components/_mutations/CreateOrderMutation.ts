import apiRequest from "@/utils/api/api";
import { PostOrderType } from "../OrderButton";
import { OrderDetailsType } from "@/types/order/OrderDetailsType";

const createOrderRequest = async (data: PostOrderType): Promise<OrderDetailsType> => apiRequest({
    method: "POST",
    url: "/orders",
    data: data
});

export default createOrderRequest;
