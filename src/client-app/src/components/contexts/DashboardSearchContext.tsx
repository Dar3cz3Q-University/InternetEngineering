"use client";

import React from "react"

type DashboardSearchContextType = {
    searchValue: string | null;
    setSearchValue: (value: string | null) => void;
    selectedCategoryIDs: string[];
    toggleSelectedCategoryID: (id: string) => void;
}

const DashboardSearchContext = React.createContext<DashboardSearchContextType>({
    searchValue: null,
    setSearchValue: () => { },
    selectedCategoryIDs: [],
    toggleSelectedCategoryID: () => { }
});

const DashboardSearchProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [searchValue, setSearchValue] = React.useState<string | null>(null);
    const [selectedCategoryIDs, setSelectedCategoryIDs] = React.useState<string[]>([]);

    const toggleSelectedCategoryID = (id: string) => {
        if (selectedCategoryIDs.includes(id)) {
            setSelectedCategoryIDs(prev => prev.filter(categoryID => categoryID !== id));
        }
        else {
            setSelectedCategoryIDs(prev => [...prev, id]);
        }
    }

    return (
        <DashboardSearchContext.Provider
            value={{
                searchValue,
                setSearchValue,
                selectedCategoryIDs,
                toggleSelectedCategoryID
            }}
        >
            {children}
        </DashboardSearchContext.Provider>
    )
}

const useDashboardSearch = (): DashboardSearchContextType => {
    const context = React.useContext(DashboardSearchContext);
    if (!context) {
        throw new Error("useDashboardSearch must be used within a DashboardSearchProvider");
    }
    return context;
}

export { DashboardSearchProvider, useDashboardSearch };
