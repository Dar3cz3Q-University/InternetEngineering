import { AddressType } from "@/types/common/AddressType";
import apiRequest from "@/utils/api/api";

const newAddressRequest = async (address: Omit<AddressType, "id">) => apiRequest({
    method: "POST",
    url: "/users/address",
    data: { address }
});

export default newAddressRequest;
