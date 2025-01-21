import { AddressType } from "../common/AddressType";
import { PriceType } from "../common/PriceType";

export type ActiveOrderType = {
    id: string;
    restaurantName: string;
    imageUrl: string;
    createdDateTime: string;
    deliveryAddress: AddressType;
    restaurantAddress: AddressType;
    estimatedDeliveryTime: string;
    totalPrice: PriceType; 
}