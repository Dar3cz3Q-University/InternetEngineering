"use client";

import { Button, Menu, MenuItem } from "@mui/material";
import React from "react";
import PlaceIcon from '@mui/icons-material/Place';

const LocationBox = () => {
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);

    const handleClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    }

    const handleClose = () => {
        setAnchorEl(null);
    }

    return (
        <div className="w-full flex flex-col justify-start">
            <p>Your location</p>
            <Button
                id="location-button"
                aria-controls={open ? "location-menu" : undefined}
                aria-haspopup="true"
                aria-expanded={open ? "true" : undefined}
                onClick={handleClick}
                startIcon={<PlaceIcon />}
            >
                Na błonie 11, Kraków   
            </Button>
            <Menu
                id="location-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                    "aria-labelledby": "location-button"
                }}
            >
                <MenuItem onClick={handleClose}>New York</MenuItem>
                <MenuItem onClick={handleClose}>Los angeles</MenuItem>
                <MenuItem onClick={handleClose}>Chicago</MenuItem>
            </Menu>
        </div>
    );
}

export default LocationBox;