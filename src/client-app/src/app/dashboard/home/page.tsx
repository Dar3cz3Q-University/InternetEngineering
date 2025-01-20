import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper"
import HomeHeader from "../../../components/dashboard/header/DashboardHeader";
import PromotionsList from "./_components/main_content/promotions/PromotionsList";
import RestaurantsTabs from "./_components/main_content/recommended_restaurants/RestaurantsTabs";
import SponsoredBanner from "./_components/main_content/SponsoredBanner";

const DashboardHomePage = () => {
    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full h-full flex flex-col justify-start items-center">
                    <div className="p-[24px]">
                        <SponsoredBanner />
                    </div>
                    <RestaurantsTabs />
                    <PromotionsList />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardHomePage;