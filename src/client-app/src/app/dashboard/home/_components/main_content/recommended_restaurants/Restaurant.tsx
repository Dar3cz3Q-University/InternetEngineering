import Image from "next/image";
import StarIcon from '@mui/icons-material/Star';

interface RestaurantProps {
    id: number;
    name: string;
    image: string;
    distance: number;
    rate: number;
}

const Restaurant: React.FC<RestaurantProps> = ({
    id,
    name,
    image,
    distance,
    rate
}) => {
    return (
        <div className="flex-shrink-0 w-[200px] h-[200px] flex flex-col shadow-lg rounded-3xl font-roboto relative">
            <div className="relative w-full h-[60%]">
                <Image
                    src={image}
                    fill={true}
                    alt="Recommended dish image"
                    style={{objectFit: "cover"}}
                    className="rounded-t-3xl"
                />
            </div>
            <div className="w-full px-[16px] py-[12px]">
                <p className="font-medium leading-none">{name}</p>
                <p className="opacity-70">{distance} km</p>
            </div>
            <div className="flex flex-row justify-end absolute bottom-[12px] right-[16px]">
                <StarIcon fontSize="small" sx={{marginTop: "1px", marginRight: "2px", color: "primary.main"}}/>
                <p className="opacity-70">{rate}</p>
            </div>
        </div>
    )
}

export default Restaurant;