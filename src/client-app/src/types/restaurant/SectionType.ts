import { RestaurantItemType } from "./RestaurantItemTtype";

export type SectionType = {
    id: string;
    name: string;
    description: string;
    items: RestaurantItemType[];
    createdDateTime?: string;
    updatedDateTime?: string;
}