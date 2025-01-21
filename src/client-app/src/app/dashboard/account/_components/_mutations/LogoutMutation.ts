import apiRequest from "@/utils/api/api";

const logoutRequest = async () => apiRequest({
    method: "POST",
    url: "/auth/logout"
});

export default logoutRequest;
