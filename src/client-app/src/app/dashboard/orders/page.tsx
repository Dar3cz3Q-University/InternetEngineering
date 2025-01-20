import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import OrdersList from "./_components/OrdersList";

const DashboardOrdersPage = () => {
    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <OrdersList />
            </DashboardPageWrapper>
        </DashboardProviders>
    );
}

export default DashboardOrdersPage;