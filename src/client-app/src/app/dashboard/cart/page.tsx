import DashboardProviders from "@/components/dashboard/providers/DashboardProviders"
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper"
import PreviousPageButton from "@/components/ui/buttons/PreviousPageButton";
import RestaurantsCartList from "./_components/RestaurantsCartList";

const DashboardCartPage = () => {
    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full h-full flex flex-col justify-start items-center p-[32px]">
                    <div className="w-full flex flex-row justify-between items-center mb-[24px]">
                        <PreviousPageButton />
                        <p className="font-bold text-xl">Cart</p>
                    </div>
                    <RestaurantsCartList />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardCartPage;