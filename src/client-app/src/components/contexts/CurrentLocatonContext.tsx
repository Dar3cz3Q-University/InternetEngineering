"use client";

import { AddressType } from "@/types/common/AddressType"
import React from "react"

type CurrentLocationContextType = {
    currentLocation: AddressType | null;
    setCurrentLocation: React.Dispatch<React.SetStateAction<AddressType | null>>;
}

const CurrentLocationContext = React.createContext<CurrentLocationContextType | undefined>(undefined);

const CurrentLocationProvider = ({children}: {children: React.ReactNode}) => {
    const [currentLocation, setCurrentLocation] = React.useState<AddressType | null>(null);

    return (
        <CurrentLocationContext.Provider value={{currentLocation, setCurrentLocation}}>
            {children}
        </CurrentLocationContext.Provider>
    )
}

const useCurrentLocation = (): CurrentLocationContextType => {
    const context = React.useContext(CurrentLocationContext);
    if (!context) {
        throw new Error("useCurrentLocation must be used within a CurrentLocationProvider");
    }
    return context;
}

export {CurrentLocationProvider, useCurrentLocation};