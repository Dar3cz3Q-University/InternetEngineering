import { CategoryType } from "@/types/common/CategoryType";
import Image from "next/image";
import Link from "next/link";

type PropType = {
    categoryData: CategoryType;
}

const CategoriesListItem = (props: PropType) => {
    const {categoryData} = props;

    return (
        <Link href={`/dashboard/menu/${categoryData.id}?categoryName=${encodeURIComponent(categoryData.name)}`} passHref>
            <div className="w-[170px] flex flex-col justify-between font-roboto">
                <div className="relative w-full h-[100px]">
                    <Image
                        src={categoryData.imageUrl}
                        fill={true}
                        alt="Restaurant image"
                        style={{objectFit: "cover"}}
                        className="rounded-xl"
                    />
                </div>
                <p className="font-medium ml-[4px] text-lg">{categoryData.name}</p>
            </div>
        </Link>
    );
}

export default CategoriesListItem;