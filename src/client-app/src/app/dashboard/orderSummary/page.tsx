"use client";

import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import PreviousPageButton from "@/components/ui/buttons/PreviousPageButton";
import { getRestaurantCart } from "@/utils/cart/cart-cookie";
import { useSearchParams } from "next/navigation";
import React from "react";
import AddressData from "./_components/AddressData";
import CartItemsData from "./_components/CartItemsData";
import OrderButton from "./_components/OrderButton";
import UserData from "./_components/UserData";

const DashboardOrderSummaryPage = () => {
    const searchParams = useSearchParams();
    const restaurantId = searchParams.get("restaurantId");
    const restaurantCart = getRestaurantCart(restaurantId);

    const calculateOrderTotal = (): number => {
        if (restaurantCart === undefined || restaurantCart === null) {
            return 0;
        }
        return restaurantCart?.items.reduce((total, item) => {
            return total + item.price.amount * item.quantity;
        }, 0);
    }

    if (restaurantCart === null) {
        return (
            <DashboardProviders>
                <DashboardPageWrapper>
                    <div className="w-full flex flex-col p-[32px]">
                    <div className="w-full flex flex-row justify-between items-center mb-[24px]">
                        <PreviousPageButton />
                            <p className="font-bold text-xl">Summary</p>
                        </div>
                        <p className="font-bold text-lg opacity-70">This cart does not exist!</p>
                    </div>
                </DashboardPageWrapper>
            </DashboardProviders>
        )
    }

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full p-[32px] flex flex-col justify-between items-center">
                    <div className="w-full flex flex-col gap-[24px]">
                        <div className="w-full flex flex-row justify-between items-center">
                            <PreviousPageButton />
                            <p className="font-bold text-xl">Summary</p>
                        </div>
                        <p className="text-2xl font-bold text-center">{restaurantCart.restaurantName}</p>
                        <UserData />
                        <AddressData />
                        <CartItemsData
                            cartData={restaurantCart}
                        />
                        <p className="font-bold text-xl">Total: {calculateOrderTotal().toFixed(2)}PLN</p>
                    </div>
                    <OrderButton 
                        restaurantId={restaurantId}
                        cartItems={restaurantCart.items}
                    />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardOrderSummaryPage;