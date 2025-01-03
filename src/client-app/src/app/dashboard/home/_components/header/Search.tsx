import { colors, InputAdornment, TextField } from "@mui/material"
import SearchIcon from '@mui/icons-material/Search';

const Search = () => {
    return (
        <TextField
            variant="outlined"
            placeholder="What you are looking for?"
            autoComplete="off"
            InputProps={{
                startAdornment: (
                    <InputAdornment position="start">
                        <SearchIcon 
                            fontSize="medium"
                            sx={{
                                color: "var(--color-white)",
                                opacity: "0.6"
                            }}
                        />
                    </InputAdornment>
                )
            }}
            sx={{
                width: "100%",
                backgroundColor: "var(--color-secondary)",
                borderRadius: "16px",
                marginTop: "16px",
                color: "#FFF",
                "& .MuiOutlinedInput-root": {
                    "& fieldset": {
                        borderRadius: "16px",
                        color: "#FFF"
                    },
                },
                "& .MuiInputBase-input": {
                    color: "var(--color-white)"
                }
            }}
        >
            
        </TextField>
    )
}

export default Search;