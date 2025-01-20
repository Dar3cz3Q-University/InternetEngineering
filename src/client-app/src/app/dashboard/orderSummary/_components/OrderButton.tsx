"use client";

import { useCurrentLocation } from "@/components/contexts/CurrentLocatonContext";
import { CartItemType } from "@/types/cart/CartItemType";
import { removeRestaurantCart } from "@/utils/cart/cart-cookie";
import Button from "@mui/material/Button/Button"
import { useRouter } from "next/navigation"

type PropType = {
    restaurantId: string | null;
    cartItems: CartItemType[];
}

type PostOrderType = {
    restaurantId: string;
    deliveryAddressId: string;
    items: {
        itemId: string;
        quantity: number;
    }[];
}

const OrderButton = (props: PropType) => {
    const {restaurantId, cartItems} = props;
    const router = useRouter();
    const {currentLocation} = useCurrentLocation();

    const handleOrder = () => {
        if (restaurantId === null) {
            return;
        }

        if (currentLocation === null) {
            return;
        }

        const postOrder: PostOrderType = {
            restaurantId: restaurantId,
            deliveryAddressId: currentLocation?.id,
            items: cartItems.map(item => ({
                itemId: item.id,
                quantity: item.quantity
            }))
        }

        console.log(postOrder);

        //TODO: POST
        
        const added = true;
        if (added) {
            removeRestaurantCart(restaurantId);
            router.push("/dashboard/orders"); //TODO: ROUTE TO ORDER DETAILS
        }
    }

    return (
        <div className="flex flex-row justify-center items-center w-[150px] h-[50px] mt-[32px]">
            <Button
                onClick={handleOrder}
                variant="contained"
                sx={{width: "100%", height: "100%"}}
            >
                ORDER
            </Button>
        </div>
    )
}

export default OrderButton;