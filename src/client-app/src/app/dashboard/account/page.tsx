"use client";

import { useUser } from "@/components/contexts/UserContext";
import DashboardProviders from "@/components/dashboard/providers/DashboardProviders";
import DashboardPageWrapper from "@/components/dashboard/wrappers/DashboardPageWrapper";
import { UserType } from "@/types/user/UserType";
import { Button, Divider } from "@mui/material";
import AddressesList from "./_components/AddressesList";
import ApplyChangesButton from "./_components/ApplyChangesButton";
import DistanceSlider from "./_components/DistanceSlider";
import UserInfo from "./_components/UserInfo";

import React from "react";
import LogoutButton from "./_components/LogoutButton";

const DashboardAccountPage = () => {
    const {user} = useUser();
    const [modifiedUser, setModifiedUser] = React.useState<UserType | null>(user);

    React.useEffect(() => {
        console.log(modifiedUser)
    }, [modifiedUser])

    return (
        <DashboardProviders>
            <DashboardPageWrapper>
                <div className="w-full h-full flex flex-col justify-start items-center p-[32px]">
                    <div className="w-full flex flex-row justify-between">
                        <UserInfo
                            user={modifiedUser}
                        />
                        <ApplyChangesButton />
                    </div>
                    <Divider
                        sx={{
                            width: "100%",
                            marginY: "16px"
                        }} 
                    />
                    <DistanceSlider
                        user={modifiedUser}
                        setUser={setModifiedUser}
                    />
                    <AddressesList
                        user={modifiedUser}
                        setUser={setModifiedUser}
                    />
                    <LogoutButton />
                </div>
            </DashboardPageWrapper>
        </DashboardProviders>
    )
}

export default DashboardAccountPage;