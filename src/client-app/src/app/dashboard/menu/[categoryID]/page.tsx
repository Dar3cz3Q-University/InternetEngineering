import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import RestaurantsList from "./_components/RestaurantsList";
import ReturnButton from "./_components/ReturnButton";

type PropType = {
    params: Promise<{categoryID: string}>;
    searchParams: Promise<{categoryName?: string}>;
}

const DashboardMenuByCategory = async (props: PropType) => {
    const categoryID = (await props.params).categoryID;
    const categoryName = (await props.searchParams).categoryName || "";

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full p-[32px]">
                    <div className="w-full mb-[32px] flex flex-row justify-between items-center">
                        <ReturnButton />
                        <p className="text-xl font-bold font-roboto">{categoryName}</p>
                    </div>
                    <RestaurantsList
                        categoryID={categoryID}
                    />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardMenuByCategory;