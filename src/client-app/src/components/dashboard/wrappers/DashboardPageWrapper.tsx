"use client";

import { useDashboardSearch } from "@/components/contexts/DashboardSearchContext";
import DashboardNavigation from "../navigation/DashboardNavigation";
import React from "react";
import SearchResults from "../search_results/SearchResults";
import DashboardHeader from "../header/DashboardHeader";

const DashboardPageWrapper: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const { searchValue } = useDashboardSearch();

    return (
        <div className="min-w-screen min-h-screen flex flex-col items-center bg-background_dark text-black overflow-x-hidden">
            <header className="w-full p-[24px]">
                <DashboardHeader />
            </header>
            <main className="w-full flex-1 flex flex-col items-center bg-background_light rounded-t-3xl mb-[54px]">
                {searchValue ? <SearchResults /> : children}
            </main>
            <nav className="fixed bottom-0 w-full">
                <DashboardNavigation />
            </nav>
        </div>
    )
}

export default DashboardPageWrapper;
