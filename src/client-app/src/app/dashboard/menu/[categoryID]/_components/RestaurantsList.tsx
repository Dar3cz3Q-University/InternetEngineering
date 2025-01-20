import { RestaurantType } from "@/types/restaurant/RestaurantType";
import RestaurantsListItem from "./RestaurantsListItem";

//DUMMY DATA FOR TESTS
const RESTAURANTS_DUMMY_DATA: Omit<RestaurantType, "description">[] = [
    { id: "81362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab1", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "82362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab2", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "83362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab3", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: false },
    { id: "84362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab4", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "85362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab5", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "86362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab6", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    { id: "87362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab7", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
]
//---

const RestaurantsList = () => {
    return (
        <div className="w-full flex flex-col items-center gap-[32px]">
            {RESTAURANTS_DUMMY_DATA.map(restaurant => (
                <RestaurantsListItem
                    key={restaurant.id}
                    restaurantData={restaurant}
                />
            ))}
        </div>
    )
}

export default RestaurantsList;