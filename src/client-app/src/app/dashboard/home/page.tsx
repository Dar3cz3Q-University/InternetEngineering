import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper"
import HomeHeader from "./_components/header/HomeHeader";
import PromotionsList from "./_components/main_content/promotions/PromotionsList";
import RestaurantsTabs from "./_components/main_content/recommended_restaurants/RestaurantsTabs";
import SponsoredBanner from "./_components/main_content/SponsoredBanner";

const DashboardHomePage = () => {
    return (
        <DashboardPageWrapper
            header={<HomeHeader />}
            main={
                <div className="w-full h-full flex flex-col justify-start items-center">
                    <div className="p-[24px]">
                        <SponsoredBanner />
                    </div>
                    <RestaurantsTabs />
                    <PromotionsList />
                </div>
            }
        />
    )
}

export default DashboardHomePage;