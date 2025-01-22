import { useDashboardSearch } from "@/components/contexts/DashboardSearchContext";
import { colors, ToggleButton, ToggleButtonGroup } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import React from "react";
import getCategoriesRequest from "./_queries/GetCategoriesQuery";

//DUMMY DATA FOR TESTS
type CategoryType = {
    id: number;
    name: string;
}

const CATEGORIES_DUMMY_DATA: CategoryType[] = [
    {id: 1, name: "Oriental"},
    {id: 2, name: "Italian"},
    {id: 3, name: "Fast food"},
    {id: 4, name: "Desserts"},
    {id: 5, name: "Polish"},
    {id: 6, name: "Vegan"}
]

const ToogleCategories = () => {
    const {
        selectedCategoryIDs,
        toggleSelectedCategoryID
    } = useDashboardSearch();

    const { data } = useQuery({
        queryKey: ['categories'],
        queryFn: getCategoriesRequest
    });

    return (
        <div className="w-full flex flex-col">
            <p className="font-bold text-lg mb-[8px]">Categories</p>
            <ToggleButtonGroup
                value={selectedCategoryIDs}
                sx={{
                    display: "flex",
                    justifyContent: "center",
                    flexWrap: "wrap",
                    gap: "8px",
                    "& .MuiToggleButton-root": {
                        borderRadius: "16px",
                        border: "1px solid var(--color-gray)",
                    }
                }}
            >
                {data?.map(category => (
                    <ToggleButton
                        key={category.id}
                        value={category.id}
                        onClick={() =>toggleSelectedCategoryID(category.id)}
                        sx={{
                            padding: "8px 16px",
                            backgroundColor: "inherit",
                            color: "var(--color-black)",
                            fontWeight: "600",
                            "&.Mui-selected": {
                                backgroundColor: "primary.main",
                                color: "var(--color-white)",
                                border: "none"
                            },
                            "&.Mui-selected:hover": {
                                backgroundColor: "primary.main",
                                border: "none"
                            },
                            "&:hover": {
                                backgroundColor: "inherit"
                            }
                        }}
                    >
                        {category.name}
                    </ToggleButton>
                ))}
            </ToggleButtonGroup>
        </div>
    )
}

export default ToogleCategories;