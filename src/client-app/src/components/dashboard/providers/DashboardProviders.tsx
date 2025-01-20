import { DashboardSearchProvider } from "@/components/contexts/DashboardSearchContext"
import React from "react"

const DashboardProviders = ({ children }: { children: React.ReactNode }) => {
    return (   
        <DashboardSearchProvider>
            {children}
        </DashboardSearchProvider>
    )
}

export default DashboardProviders;