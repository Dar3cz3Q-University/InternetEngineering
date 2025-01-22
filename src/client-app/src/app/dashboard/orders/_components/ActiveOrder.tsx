import { useToast } from "@/components/contexts/ToastContext";
import { ActiveOrderType } from "@/types/order/ActiveOrderType";
import { formatAddressToShortInfo } from "@/utils/formatters/address-formatter";
import { formatTime } from "@/utils/formatters/date-formatter";
import { Button } from "@mui/material";
import Image from "next/image";
import convert from "convert-units";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import deliverOrderRequest from "../_mutations/DeliverOrderMutation";
import formatAxiosError from "@/utils/api/error-formatter";
import { useRouter } from "next/navigation";

type PropType = {
    activeOrderData: ActiveOrderType;
}

const ActiveOrder = (props: PropType) => {
    const { activeOrderData } = props;
    const { openToast } = useToast();
    const router = useRouter();
    const { val, unit } = convert(activeOrderData.distance).from("km").toBest();

    const { mutate } = useMutation({
        mutationFn: deliverOrderRequest,
        onSuccess: () => {
            openToast("Order has been delivered successfully.", "success");
            router.refresh();
        },
        onError: (err: any) => {
            // TODO: Change any to error type
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
    });

    const handleOrderDelivery = () => {
        mutate();
    }

    return (
        <div className="flex flex-col rounded-xl shadow-xl w-full">
            <div className="relative flex-shrink-0 w-full h-[124px] rounded-xl">
                <Image
                    src={activeOrderData.imageUrl}
                    fill={true}
                    alt="Restaurant image"
                    className="rounded-t-xl object-cover"
                />
            </div>
            <div className="w-full flex flex-col p-[16px]">
                <p>Restaurant name:</p>
                <p className="font-semibold">{activeOrderData.restaurantName}</p>
                <p>Restaurant address:</p>
                <p className="font-semibold">{formatAddressToShortInfo(activeOrderData.restaurantAddress)}</p>
                <p>Distance to client:</p>
                <p className="font-semibold">{val.toFixed(2)} {unit}</p>
                <p>Delivery address:</p>
                <p className="font-semibold">{formatAddressToShortInfo(activeOrderData.deliveryAddress)}</p>
                <p>Total price:</p>
                <p className="font-semibold">{activeOrderData.totalPrice.amount} {activeOrderData.totalPrice.currency}</p>
                <p>Estimated delivery time:</p>
                <p className="font-semibold text-primary">{formatTime(activeOrderData.estimatedDeliveryTime)}</p>
            </div>
            <Button
                onClick={handleOrderDelivery}
                fullWidth
                size="large"
                variant="contained"
            >
                ORDER DELIVERED
            </Button>
        </div>
    )
}

export default ActiveOrder;
