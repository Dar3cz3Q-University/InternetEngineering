import { ActiveOrderType } from "@/types/order/ActiveOrderType";
import ActiveOrder from "./ActiveOrder";
import NearbyOrdersList from "./NearbyOrdersList";

const ACTIVE_ORDER_DUMMY_DATA: ActiveOrderType = {
    id: "89362e38-7560-40ba-9d7f-cdc388d13685",
    restaurantName: "New Lisan Kebab",
    imageUrl: "/images/dish-example.jpg",
    createdDateTime: "2025-01-17T09:36:34.052084Z",
    deliveryAddress: {
        id: "89362e38-7560-40ba-9d7f-cdc388d13684",
        street: "Skawa",
        buildingNumber: "649a",
        apartmentNumber: null,
        postalCode: "34-713",
        city: "Skawa",
        state: "Małopolska",
        country: "Polska",
        latitude: 10.5,
        longitude: 10.5
    },
    restaurantAddress: {
        id: "89362e38-7560-40ba-9d7f-cdc388d13685",
        street: "Na Błonie",
        buildingNumber: "11",
        apartmentNumber: "96",
        postalCode: "34-700",
        city: "Kraków",
        state: "Małopolska",
        country: "Polska",
        latitude: 11.5,
        longitude: 11.5
    },
    estimatedDeliveryTime: "2025-01-17T10:36:34.052084Z",
    totalPrice: {
        amount: 123.22,
        currency: "PLN"
    }
}

const NearbyOrdersWrapper = () => {
    //TODO: TAKE USER ACTIVE ORDERS
    const hasActiveOrder = false;

    if (hasActiveOrder) {
        return (
            <ActiveOrder
                activeOrderData={ACTIVE_ORDER_DUMMY_DATA}
            />
        )
    }
    else {
        return (
            <NearbyOrdersList />
        )
    }
}

export default NearbyOrdersWrapper;