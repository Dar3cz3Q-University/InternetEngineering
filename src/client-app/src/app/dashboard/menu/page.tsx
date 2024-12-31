import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper"
import MenuHeader from "./_components/header/MenuHeader";

const DashboardMenuPage = () => {
    return (
        <DashboardPageWrapper
            header={<MenuHeader />}
            main={
                <p className="h-[2000px] text-black">HOME</p>
            }
        />
    )
}

export default DashboardMenuPage;