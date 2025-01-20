"use client";

import { getCart } from "@/utils/cart/cart-cookie";
import RestaurantCart from "./RestaurantCart";

const RestaurantsCartList = () => {
    const cart = getCart();

    if (!cart || Object.keys(cart).length === 0) {
        return (
            <div className="w-full flex justify-center items-center">
                <p className="text-lg font-semibold opacity-70">Cart is empty!</p>
            </div>
        )
    }

    return (
        <div className="w-full flex flex-col items-center gap-[32px]">
            {Object.entries(cart).map(([restaurantId, restaurantData]) => (
                <RestaurantCart
                    key={restaurantId}
                    restaurantCartData={restaurantData}
                    restaurantId={restaurantId}
                />
            ))}
        </div>
    )
}

export default RestaurantsCartList;