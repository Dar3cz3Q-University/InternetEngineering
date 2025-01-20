"use client";

import { IconButton } from "@mui/material";
import ShoppingBagIcon from '@mui/icons-material/ShoppingBag';
import { useRouter } from "next/navigation";

const CartButton = () => {
    const router = useRouter();

    return (
        <IconButton
            onClick={() => router.push("/dashboard/cart")}
            sx={{
                color: "var(--color-white)", 
                backgroundColor: "var(--color-secondary)",
                width: "48px",
                height: "48px",
                "&:hover": {
                    backgroundColor: "var(--color-secondary)"
                }
            }}
        >
            <ShoppingBagIcon />
        </IconButton>
    )
}

export default CartButton;