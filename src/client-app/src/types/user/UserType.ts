import { AddressType } from "../common/AddressType";

export type UserType = {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    imageUrl: string | null;
    userRole: number;
    addresses: AddressType[];
    maxSearchDistance: number;
    createdDateTime: string;
    updatedDateTime: string;
}
