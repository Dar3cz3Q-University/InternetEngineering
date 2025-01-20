import { AddressType } from "@/types/common/AddressType";

const formatAddressToShortInfo = (address: AddressType | null): string => {
    if (address === null) {
        return "";
    }
    return `${address?.city}, ${address?.street !== address?.city ? address?.street : ""} ${address?.buildingNumber}${address?.apartmentNumber ? "/" + address?.apartmentNumber : ""}`
}

export {formatAddressToShortInfo}