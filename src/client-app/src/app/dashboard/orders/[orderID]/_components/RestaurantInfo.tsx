import Image from "next/image";

type PropType = {
    name: string;
    image: string;
}

const RestaurantInfo = (props: PropType) => {
    const {
        name,
        image
    } = props;

    return (
        <div className="w-full flex flex-col">
            <div className="relative w-full h-[150px]">
                <Image
                    src={image}
                    fill={true}
                    alt="Recommended restaurant image"
                    style={{objectFit: "cover"}}
                />
            </div>
            <p className="text-lg font-semibold mt-[8px]">{name}</p>
        </div>
    )
}

export default RestaurantInfo;