import Image from "next/image";
import StarIcon from '@mui/icons-material/Star';
import { RestaurantType } from "@/types/restaurant/RestaurantType";
import convert from "convert-units";

type PropType = {
    restaurantData: Omit<RestaurantType, "description" | "isActive" | "ratesCount">;
}

const Restaurant = (props: PropType) => {
    const { restaurantData } = props;

    const { val, unit } = convert(restaurantData.distance).from("km").toBest();

    return (
        <div className="flex-shrink-0 w-[200px] h-[200px] flex flex-col shadow-lg rounded-3xl font-roboto relative">
            <div className="relative w-full h-[60%]">
                <Image
                    src={restaurantData.imageUrl}
                    fill={true}
                    alt="Recommended restaurant image"
                    style={{ objectFit: "cover" }}
                    className="rounded-t-3xl"
                />
            </div>
            <div className="w-full px-[16px] py-[12px]">
                <p className="font-medium leading-none">{restaurantData.name}</p>
                <p className="opacity-70">{val.toFixed(2)} {unit}</p>
            </div>
            <div className="flex flex-row justify-end absolute bottom-[12px] right-[16px]">
                <StarIcon fontSize="small" sx={{ marginTop: "1px", marginRight: "2px", color: "primary.main" }} />
                <p className="opacity-70">{restaurantData.averageRate}</p>
            </div>
        </div>
    )
}

export default Restaurant;
