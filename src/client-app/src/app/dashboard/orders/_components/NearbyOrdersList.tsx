import { List } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import nearbyOrderRequest from "../_queries/NearbyOrderQuery";
import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import NearbyOrdersListItem from "./NearbyOrdersListItem";

const NearbyOrdersList = () => {
    const { currentLocation } = useCurrentLocation();

    const { data } = useQuery({
        queryKey: ['nearByOrders'],
        queryFn: () => nearbyOrderRequest(
            currentLocation?.latitude,
            currentLocation?.longitude
        )
    });

    return (
        <div className="w-full flex flex-col">
            <List sx={{ padding: "0px" }}>
                {data && data.map(order => (
                    <NearbyOrdersListItem
                        key={order.id}
                        orderData={order}
                    />
                ))}
            </List>
        </div>
    )
}

export default NearbyOrdersList;
