"use client";

import { useUser } from "@/components/contexts/UserContext";

const UserData = () => {
    const {user} = useUser();

    return (
        <div className="flex flex-col">
            <p className="font-bold text-lg">Personal Data:</p>
            <p>First name: <span className="font-semibold">{user?.firstName}</span></p>
            <p>Last name: <span className="font-semibold">{user?.lastName}</span></p>
            <p>Phone: <span className="font-semibold">{user?.phoneNumber}</span></p>
        </div>
    )
}

export default UserData;