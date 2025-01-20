import { MenuType } from "@/types/restaurant/MenuType";
import Section from "./Section";

type PropType = {
    menuData: MenuType;
    restaurantId: string;
    restaurantName: string;
}

const Menu = (props: PropType) => {
    const {menuData, restaurantId, restaurantName} = props;

    return (
        <div className="w-full flex flex-col py-[32px] gap-[32px]">
            {menuData.sections.map(section => (
                <Section
                    key={section.id}
                    sectionData={section}
                    restaurantId={restaurantId}
                    restaurantName={restaurantName}
                />
            ))}
        </div>
    )
}

export default Menu;