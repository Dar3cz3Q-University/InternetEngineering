import { useDashboardSearch } from "@/components/contexts/DashboardSearchContext";
import { ToggleButton, ToggleButtonGroup } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import React from "react";
import getCategoriesRequest from "./_queries/GetCategoriesQuery";

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
                        onClick={() => toggleSelectedCategoryID(category.id)}
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
