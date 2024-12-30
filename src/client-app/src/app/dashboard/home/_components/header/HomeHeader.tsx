import LocationBox from "./LocationBox";

const HomeHeader = () => {
    return (
        <div className="w-full h-[120px] flex flex-col justify-start text-white">
            <div className="w-full flex flex-row justify-between">
                <LocationBox />
                <p>Butt</p>
            </div>
        </div>
    )
}

export default HomeHeader;