"use client";

import { useUser } from "@/components/contexts/UserContext";
import ListSkeleton from "@/components/ui/skeletons/ListSkeleton";
import { OrderType } from "@/types/order/OrderType";
import { useQuery } from "@tanstack/react-query";
import getOrdersRequest from "../_queries/GetOrdersQuery";
import OrdersListItem from "./OrdersListItem";

const OrdersList = () => {
    const {user} = useUser();

    const { data, isLoading, error } = useQuery({
        queryKey: [user?.id],
        queryFn: () => getOrdersRequest(
            user?.id as string
        ),
        retry: false
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