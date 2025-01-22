import apiRequest from "@/utils/api/api";
import { CategoryType } from "@/types/common/CategoryType";

const getCategoriesRequest = async (): Promise<CategoryType[]> => apiRequest({
    method: "GET",
    url: "/categories"
});

export default getCategoriesRequest;
