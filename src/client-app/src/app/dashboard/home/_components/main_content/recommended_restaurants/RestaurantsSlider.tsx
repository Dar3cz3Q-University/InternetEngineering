import Restaurant from "./Restaurant";
import Carousel from "@/components/carousel/Carousel";
import { RestaurantType } from "@/types/restaurant/RestaurantType";

//DUMMY DATA FOR TESTS
const RESTAURANTS_DUMMY_DATA: { [key: string]: Omit<RestaurantType, "description" | "isActive" | "ratesCount">[] } = {
    "09362e38-7560-40ba-9d7f-cdc388d13680": [
        { id: "89362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab1", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13681", name: "Lisan Kebab2", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13682", name: "Lisan Kebab3", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13683", name: "Lisan Kebab4", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 }
    ],
    "19362e38-7560-40ba-9d7f-cdc388d13680": [
        { id: "89362e38-7560-40ba-9d7f-cdc388d13684", name: "Lisan Kebab5", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13685", name: "Lisan Kebab6", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13686", name: "Lisan Kebab7", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13687", name: "Lisan Kebab8", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
    ],
    "29362e38-7560-40ba-9d7f-cdc388d13680": [
        { id: "89362e38-7560-40ba-9d7f-cdc388d13688", name: "Lisan Kebab9", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13689", name: "Lisan Kebab10", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13610", name: "Lisan Kebab11", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13611", name: "Lisan Kebab12", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
    ],
    "39362e38-7560-40ba-9d7f-cdc388d13680": [
        { id: "89362e38-7560-40ba-9d7f-cdc388d13612", name: "Lisan Kebab13", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13613", name: "Lisan Kebab14", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13614", name: "Lisan Kebab15", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13615", name: "Lisan Kebab16", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
    ],
    "49362e38-7560-40ba-9d7f-cdc388d13680": [
        { id: "89362e38-7560-40ba-9d7f-cdc388d13616", name: "Lisan Kebab17", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13617", name: "Lisan Kebab18", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13618", name: "Lisan Kebab19", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
        { id: "89362e38-7560-40ba-9d7f-cdc388d13619", name: "Lisan Kebab20", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5 },
    ],
};
//-----

type PropType = {
    categoryID: string;
}

const RestaurantsSlider = (props: PropType) => {
    const {categoryID} = props;

    return (
        <Carousel>
            {RESTAURANTS_DUMMY_DATA[categoryID].map(restaurant => (
                <Restaurant
                    key={restaurant.id}
                    restaurantData={restaurant}
                />
            ))}
        </Carousel>
    )
}

export default RestaurantsSlider;