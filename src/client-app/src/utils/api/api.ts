import { ApiErrorResponse } from "@/types/api/ApiErrorResponse";
import axios, { AxiosError, AxiosRequestConfig } from "axios";

export type ApiError = AxiosError<ApiErrorResponse>;

const api = axios.create({
    baseURL: "http://localhost:8080",
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
