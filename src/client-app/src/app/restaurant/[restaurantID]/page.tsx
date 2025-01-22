"use client";

import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import { RestaurantDetailsType } from "@/types/restaurant/RestaurantDetailsType";
import { useQuery } from "@tanstack/react-query";
import CartRedirectButton from "./_components/CartRedirectButton";
import Menu from "./_components/Menu";
import RestaurantInfo from "./_components/RestaurantInfo";
import getRestaurantDetailsRequest from "./_queries/GetRestaurantDetailsQuery";
import React from "react";
import { useParams } from "next/navigation";
import FullscreenLoader from "@/components/ui/loaders/FullScreenLoader";

//DUMMY DATA FOR TESTS
const RESTAURANT_DUMMY_DATA: RestaurantDetailsType = {
    id: "81362e38-7560-40ba-9d7f-cdc388d13680",
    name: "New Lisan Kebab",
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
    imageUrl: "/images/dish-example.jpg",
    distance: 1.5,
    averageRate: 4.5,
    rateCount: 100,
    isActive: true,
    location: {
        id: "89362e38-7560-40ba-9d7f-cdc388d13685",
        street: "Na Błonie",
        buildingNumber: "11",
        apartmentNumber: "96",
        postalCode: "34-700",
        city: "Kraków",
        state: "Małopolska",
        country: "Polska",
        latitude: 11.5,
        longitude: 11.5
    },
    contactInfo: {
        phoneNumber: "123 456 789",
        email: "restaurant@mail.com"
    },
    openingHours: {
        openTime: "09:00:00",
        closeTime: "23:30:00"
    },
    menu: {
        id: "81362f38-7560-40ba-9d7f-cdc388d13680",
        sections: [
            {
                id: "81362f38-7560-40ba-9d7f-aac388d13680",
                name: "Rollo",
                description: "Lorem ipsum dolor sit amet",
                items: [
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368a",
                        name: "Standard Rollo",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 22, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368b",
                        name: "Small Rollo",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 18, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368c",
                        name: "Large Rollo",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 28, currency: "PLN"},
                        isAvailible: true,
                    }
                ]
            },
            {
                id: "81362f38-7560-40ba-9d7f-aac588d13680",
                name: "Rollo Meat Only",
                description: "Lorem ipsum dolor sit amet",
                items: [
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368d",
                        name: "Standard Rollo Meat Only",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 24, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368e",
                        name: "Small Rollo Meat Only",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 20, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368f",
                        name: "Large Rollo Meat Only",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 32, currency: "PLN"},
                        isAvailible: true,
                    }
                ]
            },
        ]
    }
}
//----


const RestaurantPage = () => {
    const {currentLocation} = useCurrentLocation();
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