"use client";

import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import { useQuery } from "@tanstack/react-query";
import CartRedirectButton from "./_components/CartRedirectButton";
import Menu from "./_components/Menu";
import RestaurantInfo from "./_components/RestaurantInfo";
import getRestaurantDetailsRequest from "./_queries/GetRestaurantDetailsQuery";
import React from "react";
import { useParams } from "next/navigation";
import FullscreenLoader from "@/components/ui/loaders/FullScreenLoader";

const RestaurantPage = () => {
    const { currentLocation } = useCurrentLocation();
    const params = useParams();
    const restaurantID = params.restaurantID as string;

    const { data, isLoading, isError } = useQuery({
        queryKey: [restaurantID, currentLocation?.id],
        queryFn: () => getRestaurantDetailsRequest(
            restaurantID,
            currentLocation?.latitude,
            currentLocation?.longitude
        ),
        enabled: !!restaurantID
    });

    if (isError || !data) {
        return <p>Error loading restaurant details.</p>;
    }

    if (isLoading) {
        return (
            <FullscreenLoader />
        )
    }

    return (
        <div className="w-full flex flex-col">
            <RestaurantInfo
                name={data?.name}
                description={data?.description}
                imageUrl={data?.imageUrl}
                distance={data?.distance}
                averageRate={data?.averageRate}
                rateCount={data?.rateCount}
                location={data?.location}
                contactInfo={data?.contactInfo}
                openingHours={data?.openingHours}
            />
            <Menu
                menuData={data?.menu}
                restaurantId={restaurantID}
                restaurantName={data?.name}
            />
            <CartRedirectButton
                restaurantId={restaurantID}
            />
        </div>
    )
}

export default RestaurantPage;
