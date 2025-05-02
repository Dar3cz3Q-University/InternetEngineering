"use client";

import { getRestaurantItemsCount } from "@/utils/cart/cart-cookie";
import React from "react";
import Link from "next/link";

type PropType = {
    restaurantId: string;
}

const CartRedirectButton = (props: PropType) => {
    const { restaurantId } = props;
    const [isVisible, setIsVisible] = React.useState(true);
    const [itemCount, setItemCount] = React.useState(0);

    const updateItemCount = () => {
        const count = getRestaurantItemsCount(restaurantId);
        setItemCount(count);
    }

    React.useEffect(() => {
        updateItemCount();
        const handleCartUpdate = () => {
            updateItemCount();
        }

        const handleScroll = () => {
            const scrolledToBottom = window.innerHeight + window.scrollY >= document.body.scrollHeight;
            setIsVisible(!scrolledToBottom);
        }
        window.addEventListener("scroll", handleScroll);
        window.addEventListener("cartUpdated", handleCartUpdate);

        return () => {
            window.removeEventListener("scroll", handleScroll);
            window.removeEventListener("cartUpdated", handleCartUpdate);
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [restaurantId])

    return (
        <Link href="/dashboard/cart" className={`fixed bottom-[16px] left-1/2 transform -translate-x-1/2 w-[200px] h-[50px] bg-black text-white flex items-center justify-center rounded-lg shadow-lg cursor-pointer transition-opacity duration-300 
        ${(isVisible && itemCount > 0) ? "opacity-100" : "opacity-0"}`}>
            <p>GO TO CART ({itemCount})</p>
        </Link>
    )
}

export default CartRedirectButton;
