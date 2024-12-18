import PageWrapper from "@/components/wrapper/page-wrapper";
import CartBox from "./_components/cart-box";
import LocationBox from "./_components/location-box";

const Home = () => {
    return (
        <PageWrapper>
            <div className="w-full flex flex-row items-center justify-between">
                <LocationBox />
                <CartBox />
            </div>
            
        </PageWrapper>
    )
}

export default Home;