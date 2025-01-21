import axios, { AxiosRequestConfig } from "axios";

const api = axios.create({
    baseURL: "http://localhost:8080/api/v1", // TODO: Move to .env
    withCredentials: true,
});

const apiRequest = async <T = any>(config: AxiosRequestConfig): Promise<T> => {
    if (config.data instanceof FormData) {
        config.headers = {
            ...config.headers,
            "Content-Type": "multipart/form-data",
        };
    }

    const response = await api.request<T>(config);
    return response.data;
}

export default apiRequest;
