"use client";

import { Button, Menu, MenuItem } from "@mui/material";
import React from "react";
import PlaceIcon from '@mui/icons-material/Place';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';

const LocationBox = () => {
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);

    const [currentLocation, setCurrentLocation] = React.useState<string | null>("Kraków, Plan Inwalidów 22/2");

    //TODO: Get data from API
    const DUMMY_DATA_USER_LOCATIONS: string[] = ["Kraków, Na błonie 11/96", "Kraków, Henryka Pachońskiego 13/18", "Skawa, 242"];

    const handleClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    }

    const handleClose = () => {
        setAnchorEl(null);
    }

    const handleLocationChange = (location: string) => {
        setCurrentLocation(location);
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
                startIcon={<PlaceIcon sx={{color: "primary.main"}} />}
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
                    {currentLocation}
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
                {DUMMY_DATA_USER_LOCATIONS.map((location, index) => (
                    <MenuItem 
                        key={index}
                        sx={{fontWeight: "500"}}
                        onClick={() => handleLocationChange(location)}
                    >
                        {location}
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