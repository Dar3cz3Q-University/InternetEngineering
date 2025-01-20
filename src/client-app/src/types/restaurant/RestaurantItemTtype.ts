import { PriceType } from "../common/PriceType";

export type RestaurantItemType = {
    id: string;
    name: string;
    description: string;
    imageUrl: string;
    price: PriceType;
    isAvailible: boolean;
    createdDateTime?: string;
    updatedDateTime?: string;
}