import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper"
import HomeHeader from "./_components/header/HomeHeader";

const DashboardHomePage = () => {
    return (
        <DashboardPageWrapper
            header={<HomeHeader />}
            main={
                <p className="h-[2000px] text-black">OK</p>
            }
        />
    )
}

export default DashboardHomePage;