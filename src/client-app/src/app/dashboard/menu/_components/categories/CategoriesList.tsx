"use client";

import CategoriesListItem from "./CategoriesListItem";
import { useQuery } from "@tanstack/react-query";
import getCategoriesRequest from "@/app/dashboard/home/_components/_queries/GetCategoriesQuery";

const CategoriesList = () => {

    const { data } = useQuery({
        queryKey: ['categories'],
        queryFn: getCategoriesRequest
    });

    return (
        <div className="w-full flex flex-row justify-center flex-wrap px-[24px] py-[32px] gap-[24px]">
            {data && data.map(category => (
                <CategoriesListItem
                    key={category.id}
                    categoryData={category}
                />
            ))}
        </div>
    )
}

export default CategoriesList;
