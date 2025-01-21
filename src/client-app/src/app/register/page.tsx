"use client";

import { Divider } from "@mui/material";
import UserForm from "./_components/UserForm";
import React from "react";
import { RegisterUserType } from "@/types/user/RegisterUserType";
import LocationForm from "./_components/LocationForm";
import { AddressType } from "@/types/common/AddressType";
import Link from "next/link";
import { useToast } from "@/components/contexts/ToastContext";
import jsonObjectToFormData from "@/utils/converter/JsonToFormData";
import registerMutation from "./_mutations/RegisterMutation";
import { useMutation } from "@tanstack/react-query";
import apiRequest from "@/utils/api/api";

const RegisterPage = () => {
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
    const [send, setSend] = React.useState(false);

    const registerMutation = useMutation({
        mutationFn: (userData: FormData) => {
            return apiRequest({
                method: "POST",
                url: "/auth/register",
                data: userData
            });
        },
        onSuccess: () => {
            openToast("Account created successfully", "success");
        },
        onError: (e) => {
            openToast("Could not create account", "error");
            console.error(e);
        }
    })

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
        setSend(prev => !prev);
    };

    const handleRegister = (updatedUserData: RegisterUserType) => {
        const form = jsonObjectToFormData(updatedUserData);

        registerMutation.mutate(form);
    };

    React.useEffect(() => {
        console.log(userData);
    }, [send])

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
