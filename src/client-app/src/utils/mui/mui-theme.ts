import { createTheme } from "@mui/material";
import { mui_bottom_navigation } from "./components/bottom-navigation";

const mui_theme = createTheme({
    typography: {
        fontFamily: "'Chakra Petch', sans-serif"
    },
    palette: {
        primary: {
            main: "#fe5c01"
        },
        background: {
            default: "#FAFAFA",
            paper: "#111111"
        }
    },
    components: {
        ...mui_bottom_navigation
    }
})

export {mui_theme};