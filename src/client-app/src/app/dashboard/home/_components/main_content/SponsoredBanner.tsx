import { Button } from "@mui/material";

const SponsoredBanner = () => {
    return (
        <div className="relative flex flex-row justify-start w-full bg-sponsored-banner bg-cover font-roboto rounded-3xl p-[24px] text-white">
            <div className="absolute inset-0 bg-black opacity-50 rounded-3xl"></div>
            <div className="relative w-[60%] h-full flex flex-col">
                <p className="font-semibold text-2xl leading-none">Delicious Food & Best Prices</p>
                <p className="font-normal leading-tight mt-[16px]">Treat yourself with the quality food and low prices.</p>
            </div>
            <div className="relative flex-1 flex flex-col justify-end items-end">
                <Button
                    variant="contained"
                    sx={{
                        borderRadius: "12px"
                    }}
                >
                    Details
                </Button>
            </div>
            
        </div>
    )
}

export default SponsoredBanner;