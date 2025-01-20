"use client";

import Carousel from "@/components/carousel/Carousel";
import { SectionType } from "@/types/restaurant/SectionType";
import Dish from "./Dish";

type PropType = {
    sectionData: SectionType;
    restaurantId: string;
    restaurantName: string;
}

const Section = (props: PropType) => {
    const {sectionData, restaurantId, restaurantName} = props;

    return (
        <div className="w-full flex flex-col">
            <p className="text-xl font-bold ml-[32px]">{sectionData.name}</p>
            <p className="ml-[32px] opacity-70">{sectionData.description}</p>
            <Carousel>
            {sectionData.items.map(dish => (
                <Dish
                    key={dish.id}
                    dishData={dish}
                    restaurantId={restaurantId}
                    restaurantName={restaurantName}
                />
            ))}
            </Carousel>
        </div>
    )
}

export default Section;