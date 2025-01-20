import { CartItemType } from "@/types/cart/CartItemType";

type PropType = {
    restaurantCartItemData: CartItemType;
}

const RestaurantCartItem = (props: PropType) => {
    const {restaurantCartItemData} = props;

    return (
        <div className="w-full flex">
            <p>{restaurantCartItemData.quantity}x: {restaurantCartItemData.name} ({restaurantCartItemData.price.amount}{restaurantCartItemData.price.currency})</p>
        </div>
    )
}

export default RestaurantCartItem;