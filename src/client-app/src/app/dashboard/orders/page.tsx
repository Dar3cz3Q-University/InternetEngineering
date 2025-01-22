"use client";

import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import OrdersList from "./_components/OrdersList";
import React from "react";
import { Tab, Tabs } from "@mui/material";
import { useUser } from "@/components/contexts/UserContext";
import NearbyOrdersWrapper from "./_components/NearbyOrdersWrapper";

const DashboardOrdersPage = () => {
    const { user } = useUser();
    const [selectedTab, setSelectedTab] = React.useState<number>(0);

    const handleTabChange = (event: React.SyntheticEvent, newTab: number) => {
        setSelectedTab(newTab);
    }

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full flex flex-col items-center p-[32px]">
                    {user?.userRole === 2 ? (
                        <Tabs
                            value={selectedTab}
                            onChange={handleTabChange}
                            variant="scrollable"
                            scrollButtons="auto"
                            sx={{
                                width: "100%",
                                display: "flex",
                                justifyContent: "center",
                                ".MuiTabs-flexContainer": {
                                    justifyContent: "center"
                                },
                                marginBottom: "24px"
                            }}
                        >
                            <Tab sx={{ fontSize: "16px" }} label="Your orders" />
                            <Tab sx={{ fontSize: "16px" }} label="Nearby orders" />
                        </Tabs>
                    ) : null
                    }
                    {selectedTab === 0 ? (<OrdersList />) : (<NearbyOrdersWrapper />)}
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    );
}

export default DashboardOrdersPage;
