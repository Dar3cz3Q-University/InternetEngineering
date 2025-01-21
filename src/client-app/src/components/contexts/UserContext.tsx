"use client";

import { UserType } from "@/types/user/UserType";
import React from "react";
import { useRouter, usePathname } from "next/navigation";

type UserContextType = {
    user: UserType | null;
    setUser: (user: UserType | null) => void;
    //TODO: LOGIN FUNC
    //TODO: LOGOUT FUNC
};


const UserContext = React.createContext<UserContextType | undefined>(undefined);

const UserProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const router = useRouter();
    const pathname = usePathname();
    const [user, setUser] = React.useState<UserType | null>(null);

    React.useEffect(() => {
        console.log(user)
        if (user === null && pathname.startsWith("/dashboard")) {
            router.push("/login")
        }
    }, [user])


    return (
        <UserContext.Provider
            value={{
                user,
                setUser
            }}
        >
            {children}
        </UserContext.Provider>
    );
};

const useUser = () => {
    const context = React.useContext(UserContext);
    if (!context) {
        throw new Error("useUser must be used within a UserProvider");
    }
    return context;
}

export { UserProvider, useUser };
