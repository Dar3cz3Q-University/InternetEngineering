import Image from "next/image";
import NavigateNextIcon from '@mui/icons-material/NavigateNext';
import Link from "next/link";
import { OrderType } from "@/types/order/OrderType";
import { formatDate } from "@/utils/formatters/date-formatter";

type PropType = {
    orderData: OrderType;
}

const OrdersListItem = (props: PropType) => {
    const {orderData} = props;

    return (
        <div className="w-full flex flex-row justify-between">
            <div className="flex flex-row justify-start max-w-[60%]">
                <div className="relative flex-shrink-0 w-[84px] h-[84px] rounded-xl">
                    <Image
                        src={orderData.imageUrl}
                        fill={true}
                        alt="Restaurant image"
                        className="rounded-xl object-cover"
                    />
                </div>
                <div className="w-full h-full flex flex-col justify-start ml-[16px] py-[4px]">
                    <p className="text-lg font-bold truncate">{orderData.restaurantName}</p>
                    <p className="opacity-70 truncate">Date: <span className="font-bold">{formatDate(orderData.createdDateTime)}</span></p>
                    <p className="opacity-70 truncate">Status: <span className={`${orderData.isActive ? "text-primary" : ""} font-bold`}>{orderData.orderStatus}</span></p>
                </div>
            </div>
           
           <Link href={`/dashboard/orders/${orderData.id}`}>
                <div className="h-[84px] flex flex-col justify-center items-center ml-[8px]">
                    <NavigateNextIcon fontSize="large" sx={{color: "var(--color-gray)"}} />
                </div>
            </Link>
        </div>
    )
}

export default OrdersListItem;