"use client";

import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import { useToast } from "@/components/contexts/ToastContext";
import { CartItemType } from "@/types/cart/CartItemType";
import { removeRestaurantCart } from "@/utils/cart/cart-cookie";
import Button from "@mui/material/Button/Button"
import { useMutation } from "@tanstack/react-query";
import { useRouter } from "next/navigation"
import createOrderRequest from "./_mutations/CreateOrderMutation";
import { OrderDetailsType } from "@/types/order/OrderDetailsType";
import formatAxiosError from "@/utils/api/error-formatter";

type PropType = {
    restaurantId: string | null;
    cartItems: CartItemType[];
}

export type PostOrderType = {
    restaurantId: string;
    deliveryAddressId: string;
    items: {
        itemId: string;
        quantity: number;
    }[];
}

const OrderButton = (props: PropType) => {
    const { restaurantId, cartItems } = props;
    const router = useRouter();
    const { currentLocation } = useCurrentLocation();
    const { openToast } = useToast();

    const { mutate } = useMutation({
        mutationFn: createOrderRequest,
        onSuccess: (res: OrderDetailsType) => {
            openToast("Order created successfully.", "success");
            removeRestaurantCart(res.restaurant.id);
            router.push(`/dashboard/orders/${res.id}`);
        },
        onError: (err: any) => {
            // TODO: Change any to error type
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
    });

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

        mutate(postOrder);
    }

    return (
        <div className="flex flex-row justify-center items-center w-[150px] h-[50px] mt-[32px]">
            <Button
                onClick={handleOrder}
                variant="contained"
                sx={{ width: "100%", height: "100%" }}
            >
                ORDER
            </Button>
        </div>
    )
}

export default OrderButton;
