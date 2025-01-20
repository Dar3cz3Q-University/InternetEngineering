"use client"

import { IconButton } from "@mui/material";
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import { useRouter } from "next/navigation";

const ReturnButton = () => {
    const router = useRouter();

    return (
        <IconButton 
            onClick={() => router.push("/dashboard/orders")}
            size="small" 
            sx={{
                color: "var(--color-white)", 
                backgroundColor: "var(--color-gray)",
                width: "36px",
                height: "36px",
                borderRadius: "100%",
                "&:hover": {
                    backgroundColor: "var(--color-gray)"
                }
            }}>
            <ChevronLeftIcon />
        </IconButton>
    )
}

export default ReturnButton;