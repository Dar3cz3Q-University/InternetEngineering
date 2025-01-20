import { PriceType } from "../common/PriceType";

export type CartItemType = {
    id: string;
    name: string;
    quantity: number;
    price: PriceType;
}