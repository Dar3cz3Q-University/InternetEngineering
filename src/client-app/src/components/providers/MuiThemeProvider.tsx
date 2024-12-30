"use client";

import { mui_theme } from "@/utils/mui/mui-theme"
import { CssBaseline } from "@mui/material" //TODO: fix css baseline
import { ThemeProvider } from "@mui/system"

const MuiThemeProvider = ({children}: {children: React.ReactNode}) => {
    return (
        <ThemeProvider theme={mui_theme}>
            <CssBaseline />
            {children}
        </ThemeProvider>
    )
}

export default MuiThemeProvider;