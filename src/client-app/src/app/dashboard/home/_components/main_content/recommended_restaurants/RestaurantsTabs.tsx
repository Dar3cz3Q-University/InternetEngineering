"use client";

import { CategoryType } from "@/types/common/CategoryType";
import { Tab } from "@mui/material";
import Tabs from "@mui/material/Tabs/Tabs";
import React from "react";
import RestaurantsSlider from "./RestaurantsSlider";

//DUMMY DATA FOR TESTS
const CATEGORIES_DUMMY_DATA: Omit<CategoryType, "imageUrl">[] = [
    { id: "09362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab1" },
    { id: "19362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab2" },
    { id: "29362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab3" },
    { id: "39362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab4" },
    { id: "49362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab5" },
];

const RestaurantsTabs = () => {
    const [selectedTab, setSelectedTab] = React.useState<number>(0);

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
                {CATEGORIES_DUMMY_DATA.map((category, index) => (
                    <Tab sx={{fontSize: "16px"}} label={category.name} key={index} />
                ))}
            </Tabs>
            <RestaurantsSlider categoryID={CATEGORIES_DUMMY_DATA[selectedTab].id} />
        </div>
    )
}

export default RestaurantsTabs;