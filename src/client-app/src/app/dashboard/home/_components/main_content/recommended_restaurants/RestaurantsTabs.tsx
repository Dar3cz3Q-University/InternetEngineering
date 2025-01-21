"use client";

import { Tab } from "@mui/material";
import Tabs from "@mui/material/Tabs/Tabs";
import React from "react";
import RestaurantsSlider from "./RestaurantsSlider";
import { useQuery } from "@tanstack/react-query";
import getCategoriesRequest from "../../_queries/GetCategoriesQuery";

const RestaurantsTabs = () => {
    const [selectedTab, setSelectedTab] = React.useState<number>(0);

    const { data } = useQuery({
        queryKey: ['categories'],
        queryFn: getCategoriesRequest
    });

    const handleTabChange = (event: React.SyntheticEvent, newTab: number) => {
        setSelectedTab(newTab);
    }

    return (
        <div className="w-full flex flex-col">
            <Tabs
                value={selectedTab}
                onChange={handleTabChange}
                variant="scrollable"
                scrollButtons="auto"
                sx={{
                    width: "100%",
                    paddingX: "24px",
                }}
            >
                {data && data.map((category, index) => (
                    <Tab sx={{ fontSize: "16px" }} label={category.name} key={index} />
                ))}
            </Tabs>
            {data && <RestaurantsSlider categoryID={data[selectedTab].id} />}
        </div>
    )
}

export default RestaurantsTabs;
