"use client";

import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";

const AddressData = () => {
    const { currentLocation } = useCurrentLocation();

    return (
        <div className="flex flex-col">
            <p className="font-bold text-lg">Delivery Address:</p>
            <p>Country: <span className="font-semibold">{currentLocation?.country}</span></p>
            <p>City: <span className="font-semibold">{currentLocation?.city}</span></p>
            {currentLocation?.city !== currentLocation?.street ? <p>Street: <span className="font-semibold">{currentLocation?.street}</span></p> : null}
            <p>House number: <span className="font-semibold">{currentLocation?.buildingNumber}</span></p>
            {currentLocation?.apartmentNumber ? <p>Flat number: <span className="font-semibold">{currentLocation?.apartmentNumber}</span></p> : null}
        </div>
    )
}

export default AddressData;
