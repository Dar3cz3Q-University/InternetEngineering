import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper"
import CategoriesList from "./_components/categories/CategoriesList";

const DashboardMenuPage = () => {
    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <CategoriesList />
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardMenuPage;