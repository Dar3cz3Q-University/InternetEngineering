import apiRequest from "@/utils/api/api";

const takeOrderRequest = async (orderId: string) => apiRequest({
    method: "PATCH",
    url: `/orders/${orderId}/take`
});

export default takeOrderRequest;
