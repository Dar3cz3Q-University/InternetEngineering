import { RestaurantDetailsType } from "@/types/restaurant/RestaurantDetailsType";
import CartRedirectButton from "./_components/CartRedirectButton";
import Menu from "./_components/Menu";
import RestaurantInfo from "./_components/RestaurantInfo";

//DUMMY DATA FOR TESTS
const RESTAURANT_DUMMY_DATA: RestaurantDetailsType = {
    id: "81362e38-7560-40ba-9d7f-cdc388d13680",
    name: "New Lisan Kebab",
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
    imageUrl: "/images/dish-example.jpg",
    distance: 1.5,
    averageRate: 4.5,
    rateCount: 100,
    isActive: true,
    location: {
        id: "89362e38-7560-40ba-9d7f-cdc388d13685",
        street: "Na Błonie",
        buildingNumber: "11",
        apartmentNumber: "96",
        postalCode: "34-700",
        city: "Kraków",
        state: "Małopolska",
        country: "Polska",
        latitude: 11.5,
        longitude: 11.5
    },
    contactInfo: {
        phoneNumber: "123 456 789",
        email: "restaurant@mail.com"
    },
    openingHours: {
        openTime: "09:00:00",
        closeTime: "23:30:00"
    },
    menu: {
        id: "81362f38-7560-40ba-9d7f-cdc388d13680",
        sections: [
            {
                id: "81362f38-7560-40ba-9d7f-aac388d13680",
                name: "Rollo",
                description: "Lorem ipsum dolor sit amet",
                items: [
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368a",
                        name: "Standard Rollo",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 22, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368b",
                        name: "Small Rollo",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 18, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368c",
                        name: "Large Rollo",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 28, currency: "PLN"},
                        isAvailible: true,
                    }
                ]
            },
            {
                id: "81362f38-7560-40ba-9d7f-aac588d13680",
                name: "Rollo Meat Only",
                description: "Lorem ipsum dolor sit amet",
                items: [
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368d",
                        name: "Standard Rollo Meat Only",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 24, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368e",
                        name: "Small Rollo Meat Only",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 20, currency: "PLN"},
                        isAvailible: true,
                    },
                    {
                        id: "81362f38-7560-40ba-9d7f-aac388d1368f",
                        name: "Large Rollo Meat Only",
                        imageUrl: "/images/dish-example.jpg",
                        description: "",
                        price: {amount: 32, currency: "PLN"},
                        isAvailible: true,
                    }
                ]
            },
        ]
    }
}
//----


type PropType = {
    params: Promise<{restaurantID: string}>;
}

const RestaurantPage = async (props: PropType) => {
    const restaurantID = (await props.params).restaurantID;

    return (
        <div className="w-full flex flex-col">
            <RestaurantInfo
                name={RESTAURANT_DUMMY_DATA.name}
                description={RESTAURANT_DUMMY_DATA.description}
                imageUrl={RESTAURANT_DUMMY_DATA.imageUrl}
                distance={RESTAURANT_DUMMY_DATA.distance}
                averageRate={RESTAURANT_DUMMY_DATA.averageRate}
                rateCount={RESTAURANT_DUMMY_DATA.rateCount}
                location={RESTAURANT_DUMMY_DATA.location}
                contactInfo={RESTAURANT_DUMMY_DATA.contactInfo}
                openingHours={RESTAURANT_DUMMY_DATA.openingHours}
            />
            <Menu
                menuData={RESTAURANT_DUMMY_DATA.menu}
                restaurantId={restaurantID}
                restaurantName={RESTAURANT_DUMMY_DATA.name}
            />
            <CartRedirectButton 
                restaurantId={restaurantID}
            />
        </div>
    )
}

export default RestaurantPage;