import { AddressType } from "@/types/common/AddressType";
import { NearbyOrderType } from "@/types/order/NearbyOrderType";
import { List } from "@mui/material";
import NearbyOrdersListItem from "./NearbyOrdersListItem";


const NEARBY_ORDERS_DUMMY_DATA: NearbyOrderType[] = [
    {
        id: "89362e38-7560-40ba-9d5f-cdc388d13684",
        restaurantName: "New Lisan Kebab",
        imageUrl: "/images/dish-example.jpg",
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
        }
    },
    {
        id: "89362e38-7560-40ba-9d5f-cdc388213684",
        restaurantName: "New Lisan Kebab",
        imageUrl: "/images/dish-example.jpg",
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
        }
    }
]

const NearbyOrdersList = () => {
    return (
        <div className="w-full flex flex-col">
            <List sx={{padding: "0px"}}>
                {NEARBY_ORDERS_DUMMY_DATA.map(order => (
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