import apiRequest from "@/utils/api/api";

const deliverOrderRequest = async () => apiRequest({
    method: "PATCH",
    url: "/orders/deliver"
});

export default deliverOrderRequest;
