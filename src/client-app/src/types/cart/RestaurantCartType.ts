import { CartItemType } from "./CartItemType";

export type RestaurantCartType = {
    restaurantName: string;
    items: CartItemType[];
}