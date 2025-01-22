import { useQuery } from "@tanstack/react-query";
import activeOrderRequest from "../_queries/ActiveOrderQuery";
import ActiveOrder from "./ActiveOrder";
import NearbyOrdersList from "./NearbyOrdersList";

const NearbyOrdersWrapper = () => {
    const { data } = useQuery({
        queryKey: ['active_order'],
        queryFn: activeOrderRequest,
        refetchInterval: 5000
    });

    if (data !== undefined) {
        return (
            <ActiveOrder
                activeOrderData={data}
            />
        )
    }
    return (
        <NearbyOrdersList />
    )
}

export default NearbyOrdersWrapper;
