const mui_bottom_navigation = {
    MuiBottomNavigation: {
        styleOverrides: {
            root: {
                width: "100%",
                backgroundColor: "#FAFAFA",
            }
        }
    },
    MuiBottomNavigationAction: {
        styleOverrides: {
            label: {
                fontSize: "16px",
                fontWeight: "600",
                "&.Mui-selected": {
                    fontSize: "16px",
                    fontWeight: "bold"
                }
            }
        }
    }
}

export {mui_bottom_navigation};