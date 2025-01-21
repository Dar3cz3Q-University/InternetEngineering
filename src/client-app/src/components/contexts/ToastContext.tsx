import React, { createContext, useContext, useState, ReactNode } from "react";
import { Snackbar, Alert } from "@mui/material";

type ToastType = {
    openToast: (message: string, severity?: "success" | "error" | "warning" | "info") => void;
};

const ToastContext = createContext<ToastType | undefined>(undefined);

export const ToastProvider = ({ children }: { children: ReactNode }) => {
    const [toast, setToast] = useState<{ message: string; severity: "success" | "error" | "warning" | "info"; open: boolean }>({
        message: "",
        severity: "info",
        open: false,
    });

    const openToast = (message: string, severity: "success" | "error" | "warning" | "info" = "info") => {
        setToast({ message, severity, open: true });
    };

    const closeToast = () => {
        setToast((prev) => ({ ...prev, open: false }));
    };

    return (
        <ToastContext.Provider value={{ openToast }}>
            {children}
            <Snackbar
                open={toast.open}
                autoHideDuration={6000}
                onClose={closeToast}
                anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
            >
                <Alert onClose={closeToast} severity={toast.severity} sx={{ width: "100%" }}>
                    {toast.message}
                </Alert>
            </Snackbar>
        </ToastContext.Provider>
    );
};

export const useToast = () => {
    const context = useContext(ToastContext);
    if (!context) {
        throw new Error("useToast must be used within a ToastProvider");
    }
    return context;
};
