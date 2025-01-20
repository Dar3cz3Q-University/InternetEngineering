const mui_text_field = {
    MuiTextField: {
        styleOverrides: {
            root: ({ ownerState }) => ({
                "& .MuiInputBase-root": {
                    backgroundColor: ownerState.sx?.backgroundColor || "#fff",
                },
            }),
        },
    },
    MuiInputBase: {
        styleOverrides: {
            root: ({ ownerState }) => ({
                backgroundColor: ownerState.sx?.backgroundColor || "#fff",
            }),
        },
    }
}

export {mui_text_field}