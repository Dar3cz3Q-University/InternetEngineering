import { AddressType } from "@/types/common/AddressType";
import { ContactInfoType } from "@/types/restaurant/ContactInfoType";
import { OpeningHoursType } from "@/types/restaurant/OpeningHoursType";
import Image from "next/image";
import Breadcrumbs from "@mui/material/Breadcrumbs"
import StarIcon from '@mui/icons-material/Star';
import CircleIcon from '@mui/icons-material/Circle';
import { formatShortTime } from "@/utils/formatters/date-formatter";
import { Divider } from "@mui/material";
import PreviousPageButton from "@/components/ui/buttons/PreviousPageButton";

type PropType = {
    name: string;
    description: string | null;
    imageUrl: string;
    distance: number;
    averageRate: number;
    rateCount: number;
    location: AddressType;
    contactInfo: ContactInfoType;
    openingHours: OpeningHoursType;
}

const RestaurantInfo = (props: PropType) => {
    const {
        name,
        description,
        imageUrl,
        distance,
        averageRate,
        rateCount,
        location,
        contactInfo,
        openingHours
    } = props;

    return (
        <div className="w-full flex flex-col items-center">
            <div className="absolute top-[16px] left-[16px] z-10">
                <PreviousPageButton />
            </div>
            <div className="relative w-full h-[200px]">
                <Image
                    src={imageUrl}
                    fill={true}
                    alt="Restaurant image"
                    style={{objectFit: "cover"}}
                />
            </div>
            <div className="w-full flex flex-col px-[32px] items-center">
                <p className="text-center text-2xl font-bold mt-[8px]">{name}</p>
                <div className="w-[120px] flex flex-row font-roboto justify-between items-center opacity-70">
                    <div className="flex flex-row">
                        <StarIcon fontSize="small" sx={{marginTop: "1px", marginRight: "2px", color: "primary.main"}}/>
                        <p>{averageRate}</p>
                    </div>
                    <p>{distance}km</p>
                </div>
                <p className="w-[90%] text-center mt-[8px] opacity-70">{description}</p>
                <div className="w-full flex flex-row justify-between mt-[16px]">
                    <div className="flex flex-col">
                        <p>City: <span className="font-semibold">{location.city}</span></p>
                        {location.street ? (<p>Street: <span className="font-semibold">{location.street}</span></p>) : null}
                        <p>Building: <span className="font-semibold">{location.buildingNumber}{location.apartmentNumber ? `/${location.apartmentNumber}` : ""}</span></p>
                    </div>
                    <div className="flex flex-col text-right">
                        <p className="font-semibold">{formatShortTime(openingHours.openTime)} - {formatShortTime(openingHours.closeTime)}</p>
                        <p className="font-semibold">{contactInfo.phoneNumber}</p>
                        <p className="font-semibold">{contactInfo.email}</p>
                    </div>
                </div>
                <Divider sx={{width: "100%", marginTop: "16px"}} />
            </div>
            
        </div>
    )
}

export default RestaurantInfo;