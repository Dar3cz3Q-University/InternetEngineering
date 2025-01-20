import { createTheme } from "@mui/material";
import { mui_bottom_navigation } from "./components/bottom-navigation";
import { mui_dialog } from "./components/dialog";
import { mui_text_field } from "./components/text_field";

const mui_theme = createTheme({
    typography: {
        fontFamily: "'Chakra Petch', sans-serif",
        button: {
            textTransform: "none"
        }
    },
    palette: {
        primary: {
            main: "#fe5c01",
            light: "#FFFFFF"
        },
        background: {
            default: "#FAFAFA",
            paper: "var(--color-background-dark)"
        }
    },
    components: {
        ...mui_bottom_navigation,
        ...mui_dialog,
        ...mui_text_field
    }
})

export {mui_theme};