"use client";

import ListSkeleton from "@/components/ui/skeletons/ListSkeleton";
import { useQuery } from "@tanstack/react-query";
import getOrdersRequest from "../_queries/GetOrdersQuery";
import OrdersListItem from "./OrdersListItem";

const OrdersList = () => {
    const { data, isLoading, error } = useQuery({
        queryKey: ["orders"],
        queryFn: getOrdersRequest,
        refetchInterval: 5000
    });

    if (error) {
        const errorStatus = (error as any)?.response?.status;
        if (errorStatus === 404) {
            return <p className="font-semibold text-lg">No orders found</p>;
        }
        return <p className="font-semibold text-lg">An unexpected error occurred</p>;
    }

    return (
        <div className="w-full flex flex-col gap-[32px]">
            {
                isLoading ? <ListSkeleton /> :
                    data?.map(order => (
                        <OrdersListItem
                            key={order.id}
                            orderData={order}
                        />
                    ))
            }
        </div>
    )
}

export default OrdersList;
