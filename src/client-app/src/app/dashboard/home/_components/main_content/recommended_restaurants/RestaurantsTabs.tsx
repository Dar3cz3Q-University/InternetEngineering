"use client";

import { Tab } from "@mui/material";
import Tabs from "@mui/material/Tabs/Tabs";
import React from "react";
import RestaurantsSlider from "./RestaurantsSlider";

//DUMMY DATA FOR TESTS
type DishCategory = {
    id: Number,
    name: String
}
const CATEGORIES_DUMMY_DATA: DishCategory[] = [
    { id: 0, name: "Nearest" },
    { id: 1, name: "Oriental" },
    { id: 3, name: "Italian" },
    { id: 4, name: "Fast food" },
    { id: 5, name: "Desserts" }
];

const RestaurantsTabs = () => {
    const [categoryID, setCategoryID] = React.useState<number>(0);

    const handleTabChange = (event: React.SyntheticEvent, newCategoryID: number) => {
        setCategoryID(newCategoryID);
    }

    return (
        <div className="w-full flex flex-col">
            <Tabs
                value={categoryID}
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
            <RestaurantsSlider categoryID={categoryID} />
        </div>
    )
}

export default RestaurantsTabs;