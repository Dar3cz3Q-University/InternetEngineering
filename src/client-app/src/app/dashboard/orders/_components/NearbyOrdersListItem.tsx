import { NearbyOrderType } from "@/types/order/NearbyOrderType";
import { formatAddressToShortInfo } from "@/utils/formatters/address-formatter";
import { formatDate } from "@/utils/formatters/date-formatter";
import { Button, ListItem } from "@mui/material";
import Image from "next/image";

type PropType = {
    orderData: NearbyOrderType;
}

const NearbyOrdersListItem = (props: PropType) => {
    const {orderData} = props;

    const handleTakeOrder = () => {
        console.log("OK")
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