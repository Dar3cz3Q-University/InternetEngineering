import { IconButton } from "@mui/material";
import LocationBox from "./LocationBox";
import ShoppingBagIcon from '@mui/icons-material/ShoppingBag';
import Search from "./Search";

const HomeHeader = () => {
    return (
        <div className="w-full flex flex-col justify-start text-white">
            <div className="w-full flex flex-row justify-between">
                <LocationBox />
                <IconButton sx={{
                    color: "var(--color-white)", 
                    backgroundColor: "var(--color-secondary)",
                    width: "48px",
                    height: "48px",
                    "&:hover": {
                        backgroundColor: "var(--color-secondary)"
                    }
                    }}
                >
                    <ShoppingBagIcon />
                </IconButton>
            </div>
            <Search />
        </div>
    )
}

export default HomeHeader;