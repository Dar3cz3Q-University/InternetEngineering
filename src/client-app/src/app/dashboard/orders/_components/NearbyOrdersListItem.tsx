import { useToast } from "@/components/contexts/ToastContext";
import { NearbyOrderType } from "@/types/order/NearbyOrderType";
import { formatAddressToShortInfo } from "@/utils/formatters/address-formatter";
import { Button, ListItem } from "@mui/material";
import { useMutation } from "@tanstack/react-query";
import Image from "next/image";
import takeOrderRequest from "../_mutations/TakeOrderMutation";
import formatAxiosError from "@/utils/api/error-formatter";
import convert from "convert-units";
import { useRouter } from "next/navigation";
import { AxiosError } from "axios";

type PropType = {
    orderData: NearbyOrderType;
}

const NearbyOrdersListItem = (props: PropType) => {
    const { orderData } = props;
    const { openToast } = useToast();
    const router = useRouter();
    const { val, unit } = convert(orderData.distance).from("km").toBest();

    const { mutate } = useMutation({
        mutationFn: takeOrderRequest,
        onSuccess: () => {
            openToast("Order has been taken successfully.", "success");
            router.refresh();
        },
        onError: (err: AxiosError) => {
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
    });

    const handleTakeOrder = () => {
        mutate(orderData.id);
    }

    return (
        <ListItem
            sx={{
                display: "flex",
                flexDirection: "column",
                padding: "0",
                borderRadius: "12px",
                marginBottom: "32px"
            }}
            className="shadow-xl"
        >
            <div className="relative flex-shrink-0 w-full h-[124px] rounded-xl">
                <Image
                    src={orderData.imageUrl}
                    fill={true}
                    alt="Restaurant image"
                    className="rounded-t-xl object-cover"
                />
            </div>
            <div className="w-full flex flex-col p-[16px]">
                <p>Restaurant name:</p>
                <p className="font-semibold">{orderData.restaurantName}</p>
                <p>Restaurant address:</p>
                <p className="font-semibold">{formatAddressToShortInfo(orderData.restaurantAddress)}</p>
                <p>Delivery address:</p>
                <p className="font-semibold">{formatAddressToShortInfo(orderData.deliveryAddress)}</p>
                <p>Distance to restaurant:</p>
                <p className="font-semibold">{val.toFixed(2)} {unit}</p>
            </div>
            <Button
                onClick={handleTakeOrder}
                fullWidth
                size="large"
                variant="contained"
            >
                TAKE ORDER
            </Button>
        </ListItem>
    )
}

export default NearbyOrdersListItem;
