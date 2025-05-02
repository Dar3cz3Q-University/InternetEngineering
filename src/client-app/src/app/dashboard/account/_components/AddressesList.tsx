"use client";

import { IconButton, List } from "@mui/material";
import AddressesListItem from "./AddressesListItem";
import AddIcon from '@mui/icons-material/Add';
import React from "react";
import AddAddressDialog from "./AddAddressDialog";
import { AddressType } from "@/types/common/AddressType";
import { useToast } from "@/components/contexts/ToastContext";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import newAddressRequest from "./_mutations/NewAddressMutation";
import formatAxiosError from "@/utils/api/error-formatter";
import { useUser } from "@/components/contexts/UserContext";
import { AxiosError } from "axios";

const AddressesList = () => {
    const { user } = useUser();
    const { openToast } = useToast();
    const queryClient = useQueryClient();

    const { mutate } = useMutation({
        mutationFn: newAddressRequest,
        onSuccess: () => {
            openToast("Address added successfully.", "success");
            queryClient.invalidateQueries({ queryKey: ['user'] });
        },
        onError: (err: AxiosError) => {
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
    });

    const [openAddAddressDialog, setOpenAddAddressDialog] = React.useState<boolean>(false);
    const handleAddAddressDialogOpen = () => setOpenAddAddressDialog(true);
    const handleAddAddressDialogClose = () => setOpenAddAddressDialog(false);
    const handleAddressAdd = (newAddress: Omit<AddressType, "id">) => {
        if (user) {
            mutate(newAddress);
        }
    }

    return (
        <div className="w-full flex flex-col mt-[24px]">
            <div className="w-full flex flex-row justify-between items-center">
                <p className="font-semibold text-lg">Addresses:</p>
                <IconButton
                    color="primary"
                    size="small"
                    onClick={handleAddAddressDialogOpen}
                >
                    <AddIcon />
                </IconButton>
            </div>
            <List
                sx={{
                    display: "flex",
                    flexDirection: "column",
                    gap: "8px"
                }}
            >
                {user?.addresses.map((address, index) => (
                    <AddressesListItem
                        index={index}
                        key={address.id}
                        id={address.id}
                        country={address.country}
                        city={address.city}
                        street={address.street}
                        buildingNumber={address.buildingNumber}
                        apartmentNumber={address.apartmentNumber}
                        longitude={address.longitude}
                        latitude={address.latitude}
                    />
                ))}
            </List>
            <AddAddressDialog
                open={openAddAddressDialog}
                handleClose={handleAddAddressDialogClose}
                handleAdd={handleAddressAdd}
            />
        </div>
    );
}

export default AddressesList;
