import { UserType } from "@/types/user/UserType";
import apiRequest from "@/utils/api/api";

const registerRequest = async (userData: FormData): Promise<UserType> => apiRequest({
    method: "POST",
    url: "/auth/register",
    data: userData
});

export default registerRequest;
