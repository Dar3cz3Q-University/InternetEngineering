import { IconButton } from "@mui/material"
import CheckIcon from '@mui/icons-material/Check';

const ApplyChangesButton = () => {
    return (
        <IconButton 
            sx={{
                color: "var(--color-white)", 
                backgroundColor: "var(--color-primary)",
                width: "38px",
                height: "38px",
                "&:hover": {
                    backgroundColor: "var(--color-primary)"
                }
            }}
        >
            <CheckIcon />
        </IconButton>
    )
}

export default ApplyChangesButton;