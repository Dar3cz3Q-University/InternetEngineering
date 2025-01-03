import { Divider } from "@mui/material";
import React from "react";
import Promotion from "./Promotion";

//DUMMY DATA FOR TESTS
type PromotionType = {
    id: number;
    imageUrl: string;
    title: string;
    description: string;
}

const PROMOTIONS_DUMMY_DATA: PromotionType[] = [
    {id: 1, imageUrl: "/images/promotion-example.jpg", title: "Buy two pay for one!", description: "Order large fries and enjoy second one for free. Minimum order value: 50zł."},
    {id: 2, imageUrl: "/images/promotion-example.jpg", title: "Free delivery!", description: "Free delivery in selected locations. Minimum order value: 50zł."}
]

const PromotionsList = () => {
    return (
        <div className="w-full p-[24px] font-roboto flex flex-col">
            <p className="text-xl font-bold">Promotions</p>
            {PROMOTIONS_DUMMY_DATA.map((promotion, index) => (
                <React.Fragment key={promotion.id}>
                    <Promotion
                        id={promotion.id}
                        imageUrl={promotion.imageUrl}
                        title={promotion.title}
                        description={promotion.description}
                    />
                    {index < PROMOTIONS_DUMMY_DATA.length - 1 && (<Divider />)}
                </React.Fragment>
            ))}
        </div>
    )
}

export default PromotionsList;