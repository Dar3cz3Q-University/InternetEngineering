import { AddressType } from "../common/AddressType";
import { OrderItemType } from "./OrderItemType";
import { PriceType } from "../common/PriceType";
import { RestaurantType } from "../restaurant/RestaurantType";

export type OrderDetailsType = {
    id: string;
    restaurant: RestaurantType;
    items: OrderItemType[];
    orderStatus: string;
    courierName: string | null;
    deliveryAddress: AddressType;
    totalPrice: PriceType;
    isActive: boolean;
    estimatedDeliveryTime: string;
    createdDateTime: string;
}