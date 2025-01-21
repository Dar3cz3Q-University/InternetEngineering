"use client";

import { UserType } from "@/types/user/UserType";
import React from "react";
import { useRouter, usePathname } from "next/navigation";

//DUMMY DATA FOR TESTS
const TEST_USER: UserType = 
{
    id: "c336cb26-d902-48f5-b9ff-999f3518c0d6",
    imageUrl: null,
    maxSearchDistance: 10,
    firstName: "Jakubb",
    lastName: "Latawiec",
    email: "jakublatawiec@gmail.com",
    phoneNumber: "572 478 825",
    userRole: 2,
    addresses: [
        {
            id: "89362e38-7560-40ba-9d7f-cdc388d13684",
            street: "Skawa",
            buildingNumber: "649a",
            apartmentNumber: null,
            postalCode: "34-713",
            city: "Skawa",
            state: "Małopolska",
            country: "Polska",
            latitude: 10.5,
            longitude: 10.5
        },
        {
            id: "89362e38-7560-40ba-9d7f-cdc388d13685",
            street: "Na Błonie",
            buildingNumber: "11",
            apartmentNumber: "96",
            postalCode: "34-700",
            city: "Kraków",
            state: "Małopolska",
            country: "Polska",
            latitude: 11.5,
            longitude: 11.5
        }
    ],
    createdDateTime: "2025-01-16T21:29:03.534498Z",
    updatedDateTime: "2025-01-16T21:29:03.534498Z"
}
//----


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
    const [user, setUser] = React.useState<UserType | null>(TEST_USER);

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
