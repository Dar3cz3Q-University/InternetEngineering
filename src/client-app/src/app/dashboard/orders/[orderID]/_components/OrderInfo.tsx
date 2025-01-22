import { PriceType } from "@/types/common/PriceType";
import { formatDate } from "@/utils/formatters/date-formatter";

type PropType = {
    status: string;
    date: string;
    courierName: string | null;
    total: PriceType;
}

const OrderInfo = (props: PropType) => {
    const {
        status,
        date,
        courierName,
        total
    } = props;

    return (
        <div className="w-full flex flex-col">
            <p>Status: <span className="font-semibold">{status}</span></p>
            <p>Date: <span className="font-semibold">{formatDate(date)}</span></p>
            <p>Total: <span className="font-semibold">{total.amount} {total.currency}</span></p>
            {courierName && <p>Delivered by: <span className="font-semibold">{courierName}</span></p>}
        </div>
    )
}

export default OrderInfo;
