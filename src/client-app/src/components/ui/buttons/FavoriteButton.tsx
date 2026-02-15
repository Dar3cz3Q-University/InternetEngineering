"use client";

import { IconButton } from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { useFavorites } from "@/components/contexts/FavoritesContext";

type PropType = {
    restaurantId: string;
    size?: "small" | "medium" | "large";
};

const FavoriteButton = ({ restaurantId, size = "small" }: PropType) => {
    const { isFavorite, toggleFavorite } = useFavorites();
    const favorite = isFavorite(restaurantId);

    const handleClick = (e: React.MouseEvent) => {
        e.preventDefault();
        e.stopPropagation();
        toggleFavorite(restaurantId);
    };

    return (
        <IconButton
            onClick={handleClick}
            size={size}
            sx={{
                color: favorite ? "error.main" : "var(--color-gray)",
                backgroundColor: "var(--color-white)",
                width: "32px",
                height: "32px",
                borderRadius: "100%",
                boxShadow: "0 2px 4px rgba(0,0,0,0.1)",
                "&:hover": {
                    backgroundColor: "var(--color-white)",
                },
            }}
        >
            {favorite ? <FavoriteIcon /> : <FavoriteBorderIcon />}
        </IconButton>
    );
};

export default FavoriteButton;
