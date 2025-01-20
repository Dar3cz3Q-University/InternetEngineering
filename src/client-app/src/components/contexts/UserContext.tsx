"use client";

import { UserType } from "@/types/user/UserType";
import React from "react";

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
    token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjMzM2Y2IyNi1kOTAyLTQ4ZjUtYjlmZi05OTlmMzUxOGMwZDYiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJDb3VyaWVyIiwiZ2l2ZW5fbmFtZSI6Ikpha3ViIiwiZmFtaWx5X25hbWUiOiJMYXRhd2llYyIsImp0aSI6Ijk4NDRmNzcxLTI1MzktNDVhZi04OWMyLTA5M2ZmODk4MGEzYSIsImV4cCI6MTczNzM1MzE3NiwiaXNzIjoiRGFyM2N6M1EiLCJhdWQiOiJEYXIzY3ozUSJ9.wH2wikInfrRZtLqNMxdlchQaic80nC-kw1FxEGuruNU",
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

const UserProvider: React.FC<{children: React.ReactNode}> = ({children}) => {
    const [user, setUser] = React.useState<UserType | null>(TEST_USER);

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

export {UserProvider, useUser};