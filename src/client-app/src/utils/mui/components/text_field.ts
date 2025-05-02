const mui_text_field = {
    MuiTextField: {
        styleOverrides: {
            root: (
                // @ts-expect-error backgroundColor might not exist, we're handling it
                { ownerState }
            ) => ({
                "& .MuiInputBase-root": {
                    backgroundColor: ownerState.sx?.backgroundColor || "#fff",
                },
            }),
        },
    },
    MuiInputBase: {
        styleOverrides: {
            root: (
                // @ts-expect-error backgroundColor might not exist, we're handling it
                { ownerState }
            ) => ({
                backgroundColor: ownerState.sx?.backgroundColor || "#fff",
            }),
        },
    }
}

export { mui_text_field }
