"use client";

import { CurrentLocationProvider } from "../contexts/CurrentLocatonContext";
import { UserProvider } from "../contexts/UserContext";
import MuiThemeProvider from "./MuiThemeProvider"

const MainProviders = ({children}: {children: React.ReactNode}) => {
    return (
        <MuiThemeProvider>
            <UserProvider>
                <CurrentLocationProvider>
                    {children}
                </CurrentLocationProvider>
            </UserProvider>
        </MuiThemeProvider>
    )
}

export default MainProviders;