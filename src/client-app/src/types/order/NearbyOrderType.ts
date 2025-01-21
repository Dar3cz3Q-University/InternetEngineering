import { AddressType } from "../common/AddressType";

export type NearbyOrderType = {
    id: string;
    restaurantName: string;
    imageUrl: string;
    deliveryAddress: AddressType;
    restaurantAddress: AddressType;
}
