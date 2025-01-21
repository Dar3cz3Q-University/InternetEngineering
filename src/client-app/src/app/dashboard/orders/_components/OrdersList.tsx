import { OrderType } from "@/types/order/OrderType";
import OrdersListItem from "./OrdersListItem";

//DUMMY DATA FOR TESTS
const ORDERS_DUMMY_DATA: OrderType[] = [
    { id: "89361e38-7560-40ba-9d7f-cdc388d13680", restaurantName: "New Lisan Kebab1", imageUrl: "/images/dish-example.jpg", createdDateTime: "2025-01-17T09:36:34.052084Z", orderStatus: "In progress", isActive: true },
    { id: "89362e38-7560-40ba-9d7f-cdc388d13680", restaurantName: "New Lisan Kebab2", imageUrl: "/images/dish-example.jpg", createdDateTime: "2025-01-17T09:36:34.052084Z", orderStatus: "In progress", isActive: false },
    { id: "89363e38-7560-40ba-9d7f-cdc388d13680", restaurantName: "New Lisan Kebab3", imageUrl: "/images/dish-example.jpg", createdDateTime: "2025-01-17T09:36:34.052084Z", orderStatus: "In progress", isActive: false },
    { id: "89364e38-7560-40ba-9d7f-cdc388d13680", restaurantName: "New Lisan Kebab4", imageUrl: "/images/dish-example.jpg", createdDateTime: "2025-01-17T09:36:34.052084Z", orderStatus: "In progress", isActive: false },
    { id: "89365e38-7560-40ba-9d7f-cdc388d13680", restaurantName: "New Lisan Kebab5", imageUrl: "/images/dish-example.jpg", createdDateTime: "2025-01-17T09:36:34.052084Z", orderStatus: "In progress", isActive: false },
]

const OrdersList = () => {
    return (
        <div className="w-full flex flex-col gap-[32px]">
            {ORDERS_DUMMY_DATA.map(order => (
                <OrdersListItem
                    key={order.id}
                    orderData={order}
                />
            ))}
        </div>
    )
}

export default OrdersList;