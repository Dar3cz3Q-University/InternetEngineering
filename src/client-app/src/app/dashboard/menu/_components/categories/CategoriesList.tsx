import { CategoryType } from "@/types/common/CategoryType";
import CategoriesListItem from "./CategoriesListItem";

//DUMMY DATA FOR TESTS
const CATEGORIES_DUMMY_DATA: CategoryType[] = [
    { id: "09362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab1", imageUrl: "/images/dish-example.jpg" },
    { id: "19362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab2", imageUrl: "/images/dish-example.jpg" },
    { id: "29362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab3", imageUrl: "/images/dish-example.jpg" },
    { id: "39362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab4", imageUrl: "/images/dish-example.jpg" },
    { id: "49362e38-7560-40ba-9d7f-cdc388d13680", name: "Kebab5", imageUrl: "/images/dish-example.jpg" },
]
//----


const CategoriesList = () => {
    return (
        <div className="w-full flex flex-row justify-center flex-wrap px-[24px] py-[32px] gap-[24px]">
            {CATEGORIES_DUMMY_DATA.map(category => (
                <CategoriesListItem
                    key={category.id}
                    categoryData={category}
                />
            ))}
        </div>
    )
}

export default CategoriesList;