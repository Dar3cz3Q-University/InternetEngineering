import { OrderItemType } from "@/types/order/OrderItemType";
import DishesListItem from "./DishesListItem";

type PropType = {
    dishes: OrderItemType[];
}

const DishesList = (props: PropType) => {
    const {dishes} = props;

    return (
        <div>
            <p className="text-lg font-semibold mt-[16px]">Dishes:</p>
            {dishes.map(dish => (
                <DishesListItem 
                    key={dish.id}
                    name={dish.name}
                    quantity={dish.quantity}
                />
            ))}
            
        </div>
    )
}

export default DishesList;