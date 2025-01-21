"use client";

import { Divider } from "@mui/material";
import UserForm from "./_components/UserForm";
import React from "react";
import { RegisterUserType } from "@/types/user/RegisterUserType";
import LocationForm from "./_components/LocationForm";
import { AddressType } from "@/types/common/AddressType";
import Link from "next/link";
import jsonObjectToFormData from "@/utils/converter/JsonToFormData";
import { useMutation } from "@tanstack/react-query";
import registerRequest from "./_mutations/RegisterMutation";
import { useToast } from "@/components/contexts/ToastContext";
import { UserType } from "@/types/user/UserType";
import { useUser } from "@/components/contexts/UserContext";
import { useRouter } from "next/navigation";

const RegisterPage = () => {
    const router = useRouter();
    const { setUser } = useUser();
    const [step, setStep] = React.useState(0);
    const [userData, setUserData] = React.useState<RegisterUserType>({
        email: "",
        password: "",
        firstName: "",
        lastName: "",
        phoneNumber: "",
        userRole: 1,
        image: null,
        maxSearchDistance: 8,
        address: {
            country: "",
            state: "",
            city: "",
            street: "",
            buildingNumber: "",
            apartmentNumber: null,
            postalCode: "",
            latitude: 0,
            longitude: 0
        }
    });
    const { openToast } = useToast();
    const { mutate } = useMutation({
        mutationFn: registerRequest,
        onSuccess: (res: UserType) => {
            setUser(res);
            openToast("Account created successfully.", "success");
            router.push("/dashboard/home");
        },
        onError: (e: any) => {
            // TODO: Change any to error type
            const message = e?.response?.data?.title ?? "Internal server error.";
            openToast(message, "error");
        }
    });

    const handleUserFormNext = (formData: Omit<RegisterUserType, "address">) => {
        setUserData((prev) => ({
            ...prev,
            ...formData,
        }));
        setStep(1);
    };

    const handleLocationFormNext = async (formData: Omit<AddressType, "id">) => {
        setUserData((prev) => {
            const updatedUserData = {
                ...prev,
                address: formData,
            };

            handleRegister(updatedUserData);
            return updatedUserData;
        });
    };

    const handleRegister = async (updatedUserData: RegisterUserType) => {
        const form = jsonObjectToFormData(updatedUserData);
        mutate(form);
    };

    return (
        <div className="w-full min-h-screen flex flex-col justify-center items-center p-[32px]">
            <div className="w-[90%] max-h-full flex flex-col items-center gap-[24px]">
                <p className="text-3xl font-bold">Register</p>
                {
                    step === 0 ?
                        (
                            <UserForm
                                userData={userData}
                                onNext={handleUserFormNext}
                            />
                        ) :
                        (
                            <LocationForm
                                onNext={handleLocationFormNext}
                                onPrev={() => setStep(0)}
                                locationData={userData.address}
                            />
                        )
                }

                <Divider sx={{ width: "100%" }}>OR</Divider>
                <div className="w-full flex items-center justify-center">
                    <p>Already have account?</p>
                    <Link className="font-bold text-primary ml-[8px]" href="/login">Sign in</Link>
                </div>

            </div>
        </div>
    )
}

export default RegisterPage;
function openToast(arg0: string, arg1: string) {
    throw new Error("Function not implemented.");
}
