import CartButton from "./CartButton";
import LocationBox from "./LocationBox";
import Search from "./Search";

const DashboardHeader = () => {
    return (
        <div className="w-full flex flex-col justify-start text-white">
            <div className="w-full flex flex-row justify-between">
                <LocationBox />
                <CartButton />
            </div>
            <Search />
        </div>
    )
}

export default DashboardHeader;