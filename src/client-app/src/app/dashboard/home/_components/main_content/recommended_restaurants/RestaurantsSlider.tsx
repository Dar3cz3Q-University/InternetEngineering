import Restaurant from "./Restaurant";
import Carousel from "@/components/carousel/Carousel";

//DUMMY DATA FOR TESTS
type RestaurantType = {
    id: number;
    name: string;
    image: string;
    distance: number;
    rate: number;
}

const RESTAURANTS_DUMMY_DATA: { [key: number]: RestaurantType[] } = {
    0: [
        { id: 1, name: "Pasta Carbonarad sdsdsdds", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
        { id: 2, name: "Grilled Salmon", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
        { id: 11, name: "Grilled Steak", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
    ],
    1: [
        { id: 3, name: "Pumpkin Soup", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
        { id: 4, name: "Stuffed Peppers", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
    ],
    2: [
        { id: 5, name: "Bruschetta", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
        { id: 6, name: "Garlic Bread", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
    ],
    3: [
        { id: 7, name: "Steak", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5},
        { id: 8, name: "Chicken Alfredo", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
    ],
    4: [
        { id: 9, name: "Cheesecake", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
        { id: 10, name: "Chocolate Brownie", image: "/images/dish-example.jpg", distance: 1.5, rate: 4.5 },
    ],
};
//-----

interface RestaurantsSliderProps {
    categoryID: number;
}

const RestaurantsSlider: React.FC<RestaurantsSliderProps> = ({
    categoryID
}) => {
    return (
        <Carousel>
            {RESTAURANTS_DUMMY_DATA[categoryID].map(restaurant => (
                <Restaurant
                    key={restaurant.id}
                    id={restaurant.id}
                    name={restaurant.name}
                    image={restaurant.image}
                    distance={restaurant.distance}
                    rate={restaurant.rate}
                />
            ))}
        </Carousel>
    )
}

export default RestaurantsSlider;