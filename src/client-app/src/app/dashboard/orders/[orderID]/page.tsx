import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import ReturnButton from "./_components/ReturnButton";
import DeliveryAddressInfo from "./_components/DeliveryAddressInfo";
import DishesList from "./_components/DishesList";
import OrderInfo from "./_components/OrderInfo";
import ProgressBar from "./_components/ProgressBar";
import RestaurantInfo from "./_components/RestaurantInfo";
import { OrderDetailsType } from "@/types/order/OrderDetailsType";

//DUMMY DATA FOR TESTS
const ORDER_DUMMY_DATA: OrderDetailsType = {
    id: "89363e38-7560-40ba-9d7f-cdc388d13680",
    restaurant: { id: "89362e38-7560-40ba-9d7f-cdc388d13680", name: "Lisan Kebab1", imageUrl: "/images/dish-example.jpg", distance: 1.5, averageRate: 4.5, ratesCount: 100, isActive: true },
    items: [
        {id: "89363e38-7560-40ba-9d7f-cdc188d13680", name: "Chicken", quantity: 1},
        {id: "89363e38-7560-40ba-9d7f-cdc288d13680", name: "Beef", quantity: 2},
    ],
    orderStatus: "In Progress",
    courierName: "Piotr",
    deliveryAddress: {
        id: "89362e38-7560-40ba-9d7f-cdc388d13684",
        street: "Skawa",
        buildingNumber: "649a",
        apartmentNumber: null,
        postalCode: "34-713",
        city: "Skawa",
        state: "Małopolska",
        country: "Polska",
        latitude: 10.5,
        longitude: 10.5
    },
    totalPrice: {
        amount: 100,
        currency: "PLN"
    },
    isActive: true,
    estimatedDeliveryTime: "2025-01-17T10:15:34.052084Z",
    createdDateTime: "2025-01-17T09:36:34.052084Z"
}

type PropType = {
    params: Promise<{orderID: string}>;
}

const DashboardOrderDetailsPage = async (props: PropType) => {
    const orderID = (await props.params).orderID;

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full flex flex-col p-[32px]">
                    <div className="w-full flex flex-row justify-between items-center mb-[16px]">
                        <ReturnButton />
                        <p className="text-xl text-right font-bold w-[60%]">{orderID}</p>
                    </div>
                    {
                    ORDER_DUMMY_DATA.isActive ?
                        <ProgressBar
                            createdDateTime={ORDER_DUMMY_DATA.createdDateTime}
                            estimatedDeliveryTime={ORDER_DUMMY_DATA.estimatedDeliveryTime} 
                        /> :
                        null
                    }
                    <RestaurantInfo
                        name={ORDER_DUMMY_DATA.restaurant.name}
                        image={ORDER_DUMMY_DATA.restaurant.imageUrl} 
                    />
                    <OrderInfo
                        status={ORDER_DUMMY_DATA.orderStatus}
                        date={ORDER_DUMMY_DATA.createdDateTime}
                        total={ORDER_DUMMY_DATA.totalPrice}
                        courierName={ORDER_DUMMY_DATA.courierName}
                    />
                    <DeliveryAddressInfo
                        city={ORDER_DUMMY_DATA.deliveryAddress.city}
                        street={ORDER_DUMMY_DATA.deliveryAddress.street}
                        buildingNumber={ORDER_DUMMY_DATA.deliveryAddress.buildingNumber}
                        apartmentNumber={ORDER_DUMMY_DATA.deliveryAddress.apartmentNumber}
                    />
                    <DishesList 
                        dishes={ORDER_DUMMY_DATA.items}
                    />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardOrderDetailsPage;