import { AddressType } from "../common/AddressType";
import { ContactInfoType } from "./ContactInfoType";
import { MenuType } from "./MenuType";
import { OpeningHoursType } from "./OpeningHoursType";

export type RestaurantDetailsType = {
    id: string;
    name: string;
    description: string | null;
    imageUrl: string;
    distance: number;
    averageRate: number;
    rateCount: number;
    isActive: boolean;
    location: AddressType;
    contactInfo: ContactInfoType;
    openingHours: OpeningHoursType;
    menu: MenuType;
    createdDateTime?: string;
    updatedDateTime?: string;
}