"use client";

import React, { createContext, useContext, useCallback } from "react";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import apiRequest from "@/utils/api/api";
import { useToast } from "./ToastContext";

type FavoritesResponse = {
    restaurantIds: string[];
};

type FavoritesContextType = {
    favoriteIds: string[];
    isLoading: boolean;
    isFavorite: (restaurantId: string) => boolean;
    toggleFavorite: (restaurantId: string) => void;
};

const FavoritesContext = createContext<FavoritesContextType | undefined>(undefined);

const fetchFavorites = async (): Promise<FavoritesResponse> =>
    apiRequest({
        method: "GET",
        url: "/favorites",
    });

const addFavorite = async (restaurantId: string): Promise<void> =>
    apiRequest({
        method: "POST",
        url: "/favorites",
        data: { restaurantId },
    });

const removeFavorite = async (restaurantId: string): Promise<void> =>
    apiRequest({
        method: "DELETE",
        url: `/favorites/${restaurantId}`,
    });

export const FavoritesProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const queryClient = useQueryClient();
    const { openToast } = useToast();

    const { data, isLoading } = useQuery({
        queryKey: ["favorites"],
        queryFn: fetchFavorites,
        staleTime: 1000 * 60 * 5,
    });

    const favoriteIds = data?.restaurantIds ?? [];

    const addMutation = useMutation({
        mutationFn: addFavorite,
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["favorites"] });
            openToast("Added to favorites", "success");
        },
        onError: () => {
            openToast("Failed to add to favorites", "error");
        },
    });

    const removeMutation = useMutation({
        mutationFn: removeFavorite,
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["favorites"] });
            openToast("Removed from favorites", "success");
        },
        onError: () => {
            openToast("Failed to remove from favorites", "error");
        },
    });

    const isFavorite = useCallback(
        (restaurantId: string) => favoriteIds.includes(restaurantId),
        [favoriteIds]
    );

    const toggleFavorite = useCallback(
        (restaurantId: string) => {
            if (isFavorite(restaurantId)) {
                removeMutation.mutate(restaurantId);
            } else {
                addMutation.mutate(restaurantId);
            }
        },
        [isFavorite, addMutation, removeMutation]
    );

    return (
        <FavoritesContext.Provider
            value={{
                favoriteIds,
                isLoading,
                isFavorite,
                toggleFavorite,
            }}
        >
            {children}
        </FavoritesContext.Provider>
    );
};

export const useFavorites = () => {
    const context = useContext(FavoritesContext);
    if (!context) {
        throw new Error("useFavorites must be used within a FavoritesProvider");
    }
    return context;
};
