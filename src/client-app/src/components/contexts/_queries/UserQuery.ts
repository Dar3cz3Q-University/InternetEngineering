import { UserType } from "@/types/user/UserType";
import apiRequest from "@/utils/api/api";

const userRequest = async (): Promise<UserType> => apiRequest({
    method: "GET",
    url: "/users/me"
});

export default userRequest;
