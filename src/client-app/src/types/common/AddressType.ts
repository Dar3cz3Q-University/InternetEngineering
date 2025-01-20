export type AddressType = {
    id: string;
    country: string;
    state: string;
    city: string;
    street: string;
    buildingNumber: string;
    apartmentNumber: string | null;
    postalCode: string;
    latitude: number;
    longitude: number;
}