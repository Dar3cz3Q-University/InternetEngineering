import { AddressType } from "../common/AddressType";

export type RegisterUserType = {
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    userRole: number;
    avatarImage: File | null;
    maxSearchDistance: number;
    address: Omit<AddressType, "id">;
}