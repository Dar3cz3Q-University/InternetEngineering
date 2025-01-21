"use client";

import { useUser } from "@/components/contexts/UserContext";
import { Slider } from "@mui/material";

const DistanceSlider = () => {
    const { user, setUser } = useUser();

    const marks = [
        { value: 1, label: "1 km" },
        { value: 8, label: "8 km" },
        { value: 15, label: "15 km" },
    ]

    const handelDistanceChange = (event: Event, newValue: number | number[]) => {
        if (user) {
            setUser({ ...user, maxSearchDistance: newValue as number });
        }
    }

    return (
        <div className="w-full flex flex-col mt-[16px]">
            <p className="font-semibold text-lg">Set max distance:</p>
            <div className="w-full">
                <Slider
                    value={user?.maxSearchDistance || 8}
                    min={1}
                    max={15}
                    valueLabelDisplay="auto"
                    marks={marks}
                    onChange={handelDistanceChange}
                />
            </div>
        </div>
    )
}

export default DistanceSlider;
