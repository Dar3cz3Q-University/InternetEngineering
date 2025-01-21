"use client";

import { Button, Menu, MenuItem } from "@mui/material";
import React from "react";
import PlaceIcon from '@mui/icons-material/Place';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import { useUser } from "@/components/contexts/UserContext";
import { useCurrentLocation } from "@/components/contexts/CurrentLocationContext";
import { AddressType } from "@/types/common/AddressType";

const LocationBox = () => {
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);

    const { user } = useUser();
    const { currentLocation, setCurrentLocation } = useCurrentLocation();

    React.useEffect(() => {
        if (user?.addresses && user.addresses.length > 0 && !currentLocation) {
            setCurrentLocation(user?.addresses[0]);
        }
    }, [user, currentLocation, setCurrentLocation])

    const handleClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    }

    const handleClose = () => {
        setAnchorEl(null);
    }

    const handleLocationChange = (address: AddressType) => {
        if (address !== currentLocation) {
            setCurrentLocation(address);
        }
        handleClose();
    }

    return (
        <div className="w-full flex flex-col justify-start items-start">
            <p className="text-sm font-light opacity-60">Your location</p>
            <Button
                id="location-button"
                aria-controls={open ? "location-menu" : undefined}
                aria-haspopup="true"
                aria-expanded={open ? "true" : undefined}
                onClick={handleClick}
                startIcon={<PlaceIcon sx={{ color: "primary.main" }} />}
                endIcon={open ? <ExpandLessIcon /> : <ExpandMoreIcon />}
                sx={{
                    color: "var(--color-white)",
                    padding: "0px",
                    fontWeight: "400",
                    display: "flex",
                    justifyContent: "start",
                    maxWidth: "90%",
                    fontSize: "16px"
                }}
            >
                <span className="overflow-hidden text-ellipsis whitespace-nowrap">
                    {`${currentLocation?.city}, ${currentLocation?.street !== currentLocation?.city ? currentLocation?.street : ""} ${currentLocation?.buildingNumber}${currentLocation?.apartmentNumber ? "/" + currentLocation?.apartmentNumber : ""}`}
                </span>
            </Button>
            <Menu
                id="location-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                    "aria-labelledby": "location-button",
                }}
                PaperProps={{
                    sx: {
                        width: "auto",
                        backgroundColor: "primary.light",
                        marginTop: "8px"
                    }
                }}
            >
                {user?.addresses.map(address => (
                    <MenuItem
                        key={address.id}
                        sx={{ fontWeight: "500" }}
                        onClick={() => handleLocationChange(address)}
                    >
                        {`${address.city}, ${address.street !== address.city ? address.street : ""} ${address.buildingNumber}${address.apartmentNumber ? "/" + address.apartmentNumber : ""}`}
                    </MenuItem>
                ))}
                <MenuItem sx={{
                    color: "primary.main",
                    fontWeight: "600"
                }}
                    onClick={handleClose}>
                    Get current location
                </MenuItem>
            </Menu>
        </div>
    );
}

export default LocationBox;
