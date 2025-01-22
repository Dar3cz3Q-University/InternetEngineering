import { AddressType } from "../common/AddressType";

export type NearbyOrderType = {
    id: string;
    restaurantName: string;
    imageUrl: string;
    distance: number;
    deliveryAddress: AddressType;
    restaurantAddress: AddressType;
    updatedDateTime: string;
    createdDateTime: string;
}
