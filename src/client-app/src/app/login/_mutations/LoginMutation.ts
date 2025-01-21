import { LoginType } from "@/types/user/LoginType";
import { UserType } from "@/types/user/UserType";
import apiRequest from "@/utils/api/api";

const loginRequest = async (loginData: LoginType): Promise<UserType> => apiRequest({
    method: "POST",
    url: "/auth/login",
    data: loginData
});

export default loginRequest;
