import { formatTime } from "@/utils/formatters/date-formatter";
import { LinearProgress } from "@mui/material";

type PropType = {
    createdDateTime: string;
    estimatedDeliveryTime: string;
}

const ProgressBar = (props: PropType) => {
    const {
        createdDateTime,
        estimatedDeliveryTime
    } = props;

    return (
        <div className="w-full flex flex-col mb-[24px]">
            <div className="w-full flex flex-row justify-between">
                <p>{formatTime(createdDateTime)}</p>
                <p>{formatTime(estimatedDeliveryTime)}</p>
            </div>
            <LinearProgress />
        </div>
    )
}

export default ProgressBar;