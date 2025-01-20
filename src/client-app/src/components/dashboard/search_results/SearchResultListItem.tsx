import Image from "next/image";
import StarIcon from '@mui/icons-material/Star';
import { RestaurantType } from "@/types/restaurant/RestaurantType";

type PropType = {
    restaurantData: Omit<RestaurantType, "description">;
}

const SearchResultListItem = (props: PropType) => {
    const {restaurantData} = props;

    return (
        <div className={`flex-shrink-0 w-full h-[250px] flex flex-col shadow-lg rounded-3xl font-roboto relative ${!restaurantData.isActive ? "opacity-80 grayscale pointer-events-none" : ""}`}>
            <div className="relative w-full h-[70%]">
                <Image
                    src={restaurantData.imageUrl}
                    fill={true}
                    alt="Restaurant image"
                    style={{objectFit: "cover"}}
                    className="rounded-t-3xl"
                />
            </div>
            <div className="w-full px-[16px] py-[12px] mt-[4px]">
                <p className="font-medium leading-none">{restaurantData.name}</p>
                <p className="opacity-70">{restaurantData.distance} km</p>
            </div>
            <div className="flex flex-row justify-end absolute bottom-[12px] right-[16px]">
                <StarIcon fontSize="small" sx={{marginTop: "1px", marginRight: "2px", color: "primary.main"}}/>
                <p className="opacity-70">{restaurantData.averageRate} ({restaurantData.ratesCount})</p>
            </div>
        </div>
    );
}

export default SearchResultListItem;