"use client";

import { IconButton, List } from "@mui/material";
import AddressesListItem from "./AddressesListItem";
import AddIcon from '@mui/icons-material/Add';
import React from "react";
import AddAddressDialog from "./AddAddressDialog";
import { UserType } from "@/types/user/UserType";
import { AddressType } from "@/types/common/AddressType";

type PropType = {
    user: UserType | null;
    setUser: React.Dispatch<React.SetStateAction<UserType | null>>;
}

const AddressesList = (props: PropType) => {
    const {user, setUser} = props;

    const [openAddAddressDialog, setOpenAddAddressDialog] = React.useState<boolean>(false);
    const handleAddAddresDialogOpen = () => setOpenAddAddressDialog(true);
    const handleAddAddresDialogClose = () => setOpenAddAddressDialog(false);
    const handleAddressAdd = (newAddress: Omit<AddressType, "id">) => {
        if (user) {
            const updatedAddresses = [
                ...user.addresses,
                {...newAddress, id: `${user.addresses.length + 1}`}
            ];
            setUser({...user, addresses: updatedAddresses})
        }
    }

    return (
        <div className="w-full flex flex-col mt-[24px]">
            <div className="w-full flex flex-row justify-between items-center">
                <p className="font-semibold text-lg">Addresses:</p>
                <IconButton 
                    color="primary" 
                    size="small"
                    onClick={handleAddAddresDialogOpen}
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
                handleClose={handleAddAddresDialogClose}
                handleAdd={handleAddressAdd}
            />
        </div>
    );
}

export default AddressesList;