import DashboardNavigation from "../navigation/DashboardNavigation";

interface DashboardPageWrapperProps {
    header: React.ReactNode;
    main: React.ReactNode;
}

const DashboardPageWrapper: React.FC<DashboardPageWrapperProps> = ({
    header,
    main
}) => {
    return (
        <div className="min-w-screen min-h-screen flex flex-col items-center bg-background_dark text-black">
            <header className="w-full p-[24px]">
                {header}
            </header>
            <main className="w-full flex-1 flex flex-col items-center bg-background_light">
                {main}
            </main>
            <nav className="fixed bottom-0 w-full shadow-lg">
                <DashboardNavigation />
            </nav>
        </div>
    )
}

export default DashboardPageWrapper;