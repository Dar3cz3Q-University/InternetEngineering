import { Button } from "@mui/material";

const LogoutButton = () => {

    const handleLogout = () => {
        console.log("LOGOUT")
    }

    return (
        <div className="w-full px-[32px] fixed bottom-[88px] left-0">
            <Button
                onClick={handleLogout}
                fullWidth
                variant="outlined"
                size="large"
                color="error"
            >
                LOGOUT
            </Button>
        </div>
    )
}

export default LogoutButton;