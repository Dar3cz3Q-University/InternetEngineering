"use client";

import MuiThemeProvider from "./MuiThemeProvider"

const MainProviders = ({children}: {children: React.ReactNode}) => {
    return (
        <MuiThemeProvider>
            {children}
        </MuiThemeProvider>
    )
}

export default MainProviders;