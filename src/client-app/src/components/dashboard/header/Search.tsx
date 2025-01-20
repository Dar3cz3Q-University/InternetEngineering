"use client";

import { InputAdornment, TextField } from "@mui/material"
import SearchIcon from '@mui/icons-material/Search';
import { useDashboardSearch } from "@/components/contexts/DashboardSearchContext";

const Search = () => {
    const {setSearchValue, searchValue} = useDashboardSearch();

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value;
        setSearchValue(value.trim() === '' ? null : value);
    }

    return (
        <TextField
            variant="outlined"
            placeholder="What you are looking for?"
            autoComplete="off"
            onChange={handleInputChange}
            value={searchValue || ''}
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