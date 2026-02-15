"use client";

import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import { useFavorites } from "@/components/contexts/FavoritesContext";
import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import { useQueries } from "@tanstack/react-query";
import apiRequest from "@/utils/api/api";
import { RestaurantType } from "@/types/restaurant/RestaurantType";
import Restaurant from "../home/_components/main_content/recommended_restaurants/Restaurant";
import { CircularProgress } from "@mui/material";

const getRestaurantRequest = async (
    restaurantId: string,
    lat?: number,
    lng?: number
): Promise<RestaurantType> =>
    apiRequest({
        method: "GET",
        url: `/restaurants/${restaurantId}`,
        params: {
            latitude: lat,
            longitude: lng,
        },
    });

const DashboardFavoritesPage = () => {
    const { favoriteIds, isLoading: favoritesLoading } = useFavorites();
    const { currentLocation } = useCurrentLocation();

    const restaurantQueries = useQueries({
        queries: favoriteIds.map((id) => ({
            queryKey: ["restaurant", id, currentLocation?.id],
            queryFn: () =>
                getRestaurantRequest(
                    id,
                    currentLocation?.latitude,
                    currentLocation?.longitude
                ),
            enabled: !!currentLocation,
            staleTime: 1000 * 60 * 5,
        })),
    });

    const isLoading = favoritesLoading || restaurantQueries.some((q) => q.isLoading);
    const restaurants = restaurantQueries
        .filter((q) => q.isSuccess && q.data)
        .map((q) => q.data as RestaurantType);

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full flex flex-col items-center p-[32px]">
                    <h1 className="text-2xl font-bold mb-[24px]">Favorite Restaurants</h1>
                    {isLoading ? (
                        <CircularProgress />
                    ) : restaurants.length === 0 ? (
                        <p className="text-gray-500">
                            No favorite restaurants yet. Start adding some!
                        </p>
                    ) : (
                        <div className="w-full grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
                            {restaurants.map((restaurant) => (
                                <Restaurant
                                    key={restaurant.id}
                                    restaurantData={restaurant}
                                />
                            ))}
                        </div>
                    )}
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    );
};

export default DashboardFavoritesPage;
