"use client";

import { UserType } from "@/types/user/UserType";
import React from "react";
import { useRouter, usePathname } from "next/navigation";
import { useQuery } from "@tanstack/react-query";
import userRequest from "./_queries/UserQuery";
import isAuthenticated from "@/utils/auth/auth";

type UserContextType = {
    user: UserType | null;
    setUser: (user: UserType | null) => void;
    login: (user: UserType | null) => void;
    logout: () => void;
};

const UserContext = React.createContext<UserContextType | undefined>(undefined);

const excludedPaths = ["/login", "/register"];

const UserProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const router = useRouter();
    const pathname = usePathname();
    const [user, setUser] = React.useState<UserType | null>(null);

    const login = (user: UserType | null) => {
        setUser(user);
        router.push("/dashboard/home");
    }

    const logout = () => {
        setUser(null);
    }

    const { data, isLoading } = useQuery({
        queryKey: ['user'],
        queryFn: userRequest
    });

    React.useEffect(() => {
        console.log(user);
    }, [user])

    React.useEffect(() => {
        console.log(user);
    }, [user])

    React.useEffect(() => {
        if (!isAuthenticated() && !excludedPaths.includes(pathname)) {
            router.push("/login")
        }

        setUser(data || null);
    }, [data, isLoading])

    return (
        <UserContext.Provider
            value={{
                user,
                setUser,
                login,
                logout
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
