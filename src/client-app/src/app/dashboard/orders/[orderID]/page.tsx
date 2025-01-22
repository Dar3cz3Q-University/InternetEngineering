"use client";

import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import ReturnButton from "./_components/ReturnButton";
import DeliveryAddressInfo from "./_components/DeliveryAddressInfo";
import DishesList from "./_components/DishesList";
import OrderInfo from "./_components/OrderInfo";
import ProgressBar from "./_components/ProgressBar";
import RestaurantInfo from "./_components/RestaurantInfo";
import { useParams } from "next/navigation";
import { useQuery } from "@tanstack/react-query";
import getOrderDetailsRequest from "./_queries/OrderDetailsQuery";

const DashboardOrderDetailsPage = () => {
    const params = useParams();
    const orderID = params.orderID;

    const { data } = useQuery({
        queryKey: ["orders", orderID],
        queryFn: () => getOrderDetailsRequest(orderID as string),
        refetchInterval: 2000
    });

    if (!data) {
        return null;
    }

    console.log(data);

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full flex flex-col p-[32px]">
                    <div className="w-full flex flex-row justify-between items-center mb-[16px]">
                        <ReturnButton />
                        <p className="text-xl text-right font-bold w-[60%]">{orderID}</p>
                    </div>
                    {
                        data.isActive ?
                            <ProgressBar
                                createdDateTime={data.createdDateTime}
                                estimatedDeliveryTime={data.estimatedDeliveryDateTime}
                            /> :
                            null
                    }
                    <RestaurantInfo
                        name={data.restaurant.name}
                        image={data.restaurant.imageUrl}
                    />
                    <OrderInfo
                        status={data.orderStatus}
                        date={data.createdDateTime}
                        total={data.totalPrice}
                        courierName={data.courierName}
                    />
                    <DeliveryAddressInfo
                        city={data.deliveryAddress.city}
                        street={data.deliveryAddress.street}
                        buildingNumber={data.deliveryAddress.buildingNumber}
                        apartmentNumber={data.deliveryAddress.apartmentNumber}
                    />
                    <DishesList
                        dishes={data.items}
                    />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardOrderDetailsPage;
