"use client";

import { BottomNavigation, BottomNavigationAction } from "@mui/material";
import React from "react";
import HomeIcon from '@mui/icons-material/Home';
import RestaurantMenuIcon from '@mui/icons-material/RestaurantMenu';
import HistoryIcon from '@mui/icons-material/History';
import PersonIcon from '@mui/icons-material/Person';
import { useRouter, usePathname } from "next/navigation";

const DashboardNavigation = () => {
    const [value, setValue] = React.useState<number>(0);
    const router = useRouter();
    const pathname = usePathname();

    React.useEffect(() => {
        const currentRouteIndex = routes.findIndex(route =>
            pathname.startsWith(route)
        );
        if (currentRouteIndex !== -1) {
            setValue(currentRouteIndex);
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [pathname])

    const routes = [
        "/dashboard/home",
        "/dashboard/menu",
        "/dashboard/orders",
        "/dashboard/account"
    ]

    return (
        <BottomNavigation
            showLabels
            value={value}
            onChange={(event, newValue) => {
                if (newValue !== value) {
                    setValue(newValue);
                    router.push(routes[newValue]);
                }
            }}
        >
            <BottomNavigationAction label="Home" icon={<HomeIcon />} />
            <BottomNavigationAction label="Menu" icon={<RestaurantMenuIcon />} />
            <BottomNavigationAction label="Orders" icon={<HistoryIcon />} />
            <BottomNavigationAction label="Account" icon={<PersonIcon />} />
        </BottomNavigation>
    )
}

export default DashboardNavigation;
