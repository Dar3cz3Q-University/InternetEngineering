import apiRequest from "@/utils/api/api";

const changeDistanceRequest = async (value: number) => apiRequest({
    method: "PATCH",
    url: "/users/max-search-distance",
    data: {
        "maxSearchDistance": value
    }
});

export default changeDistanceRequest;
