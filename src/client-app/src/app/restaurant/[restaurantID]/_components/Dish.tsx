"use client";

import { RestaurantItemType } from "@/types/restaurant/RestaurantItemTtype";
import Image from "next/image";
import AddIcon from '@mui/icons-material/Add';
import { CircularProgress, IconButton } from "@mui/material";

import React from "react";
import { addToCart } from "@/utils/cart/cart-cookie";

type PropType = {
    dishData: RestaurantItemType;
    restaurantId: string;
    restaurantName: string;
}

const Dish = (props: PropType) => {
    const { dishData, restaurantId, restaurantName } = props;
    const [loading, setLoading] = React.useState(false);

    const handleAddItem = async () => {
        setLoading(true);
        try {
            await new Promise(resolve => setTimeout(resolve, 500));

            addToCart(
                restaurantId,
                restaurantName,
                {
                    id: dishData.id,
                    name: dishData.name,
                    quantity: 1,
                    price: dishData.price
                }
            );
        } finally {
            setLoading(false);
        }
    }

    return (
        <div className="flex-shrink-0 w-[200px] h-[200px] flex flex-col shadow-lg rounded-3xl font-roboto relative">
            <div className="relative w-full h-[60%]">
                <Image
                    src={dishData.imageUrl}
                    fill={true}
                    alt="Dish image"
                    style={{ objectFit: "cover" }}
                    className="rounded-t-3xl"
                />
            </div>
            <div className="w-full px-[16px] py-[12px]">
                <p className="font-medium leading-none">{dishData.name}</p>
                <p className="opacity-70">{dishData.price.amount} {dishData.price.currency}</p>
            </div>
            <div className="absolute bottom-[12px] right-[16px]">
                <IconButton
                    onClick={handleAddItem}
                    size="small"
                    sx={{
                        color: "var(--color-white)",
                        backgroundColor: "var(--color-primary)",
                        width: "32px",
                        height: "32px",
                        borderRadius: "100%",
                        "&:hover": {
                            backgroundColor: "var(--color-primary)"
                        }
                    }}>
                    {loading ? (
                        <CircularProgress size={16} color="inherit" />
                    ) : (
                        <AddIcon />
                    )}
                </IconButton>
            </div>
        </div>
    )
}

export default Dish;
