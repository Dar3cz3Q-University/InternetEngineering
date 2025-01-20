type PropType = {
    quantity: number;
    name: string;
}

const DishesListItem = (props: PropType) => {
    const {
        quantity,
        name
    } = props;

    return (
        <div className="w-full flex flex-row justify-start">
            <p className="w-[28px]">{quantity}x: </p>
            <p className="font-semibold">{name}</p>
        </div>
    )
}

export default DishesListItem;