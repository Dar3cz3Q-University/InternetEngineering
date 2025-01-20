"use client";

import { RestaurantCartType } from "@/types/cart/RestaurantCartType";

type PropType = {
    cartData: RestaurantCartType;
}

const CartItemsData = (props: PropType) => {
    const {cartData} = props;

    return (
        <div className="flex flex-col">
            <p className="font-bold text-lg">Dishes:</p>
            {cartData.items.map(item => (
                <p key={item.id}>
                    {item.quantity}x: <span className="font-semibold">{item.name}</span> ({item.price.amount}{item.price.currency})
                </p>
            ))}
        </div>
    )
}

export default CartItemsData;