import { RestaurantCartType } from "@/types/cart/RestaurantCartType";
import { Button, IconButton } from "@mui/material";
import RestaurantCartItem from "./RestaurantCartItem";
import DeleteIcon from '@mui/icons-material/Delete';
import { removeRestaurantCart } from "@/utils/cart/cart-cookie";
import { useRouter } from "next/navigation";

type PropType = {
    restaurantCartData: RestaurantCartType;
    restaurantId: string;
}

const RestaurantCart = (props: PropType) => {
    const {restaurantCartData, restaurantId} = props;
    const router = useRouter();

    const handleCartDelete = () => {
        removeRestaurantCart(restaurantId);
        router.refresh();
    }

    const handleOrder = () => {
        router.push(`/dashboard/orderSummary?restaurantId=${restaurantId}`);
    }

    return (
        <div className="w-full flex flex-col shadow-lg p-[16px] rounded-xl">
            <div className="w-full flex flex-row justify-between items-center">
                <p className="text-xl font-bold">{restaurantCartData.restaurantName}</p>
                <IconButton 
                    size="small"
                    onClick={handleCartDelete}
                >
                    <DeleteIcon />
                </IconButton>
            </div>
            <div className="w-full flex flex-col mt-[8px]">
                {restaurantCartData.items.map(item => (
                    <RestaurantCartItem
                        key={item.id}
                        restaurantCartItemData={item}
                    />
                ))}
            </div>
            <Button
                onClick={handleOrder}
                variant="contained" 
                sx={{marginTop: "16px"}}
            >
                ORDER
            </Button>
        </div>
    )
}

export default RestaurantCart;