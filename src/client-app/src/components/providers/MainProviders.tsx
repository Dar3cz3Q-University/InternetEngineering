"use client";

import { CurrentLocationProvider } from "../contexts/CurrentLocatonContext";
import { ToastProvider } from "../contexts/ToastContext";
import { UserProvider } from "../contexts/UserContext";
import MuiThemeProvider from "./MuiThemeProvider"
import QueryProvider from "./ReactQueryProvider";

const MainProviders = ({ children }: { children: React.ReactNode }) => {
    return (
        <MuiThemeProvider>
            <QueryProvider>
                <UserProvider>
                    <CurrentLocationProvider>
                        <ToastProvider>
                            {children}
                        </ToastProvider>
                    </CurrentLocationProvider>
                </UserProvider>
            </QueryProvider>
        </MuiThemeProvider>
    )
}

export default MainProviders;
