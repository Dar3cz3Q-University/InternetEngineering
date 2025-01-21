import { ApiErrorResponse } from "@/types/api/ApiErrorResponse";
import axios, { AxiosError, AxiosRequestConfig } from "axios";

export type ApiError = AxiosError<ApiErrorResponse>;

const api = axios.create({
    baseURL: "http://maselniczka:8080/api/v1", // TODO: Move to .env
    withCredentials: true,
});

const apiRequest = async <T>(config: AxiosRequestConfig): Promise<T> => {
    if (config.data instanceof FormData) {
        config.headers = {
            ...config.headers,
            "Content-Type": "multipart/form-data",
        };
    }

    const response = await api.request<T>(config);
    return response.data;
};

export default apiRequest;
