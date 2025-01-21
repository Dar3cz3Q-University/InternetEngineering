import { ActiveOrderType } from "@/types/order/ActiveOrderType";
import { formatAddressToShortInfo } from "@/utils/formatters/address-formatter";
import { formatTime } from "@/utils/formatters/date-formatter";
import { Button } from "@mui/material";
import Image from "next/image";

type PropType = {
    activeOrderData: ActiveOrderType;
}

const ActiveOrder = (props: PropType) => {
    const {activeOrderData} = props;

    const handleOrderDelivery = () => {
        console.log("OK");
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