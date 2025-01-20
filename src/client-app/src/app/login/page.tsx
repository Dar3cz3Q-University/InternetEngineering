"use client";

import { LoginType } from "@/types/user/LoginType";
import { isValidEmail, isValidPassword } from "@/utils/validators/regexes";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { Button, Divider, IconButton, InputAdornment, Link, TextField } from "@mui/material";
import React from "react";

const LoginPage = () => {
    const [formData, setFormData] = React.useState<LoginType>({
        email: "",
        password: ""
    });

    const [errors, setErrors] = React.useState({
        email: false,
        password: false,
        invalidUserData: false
    });

    const validateFields = () => {
        const newErrors = {
            email: !isValidEmail(formData.email),
            password: !isValidPassword(formData.password),
            invalidUserData: false
        }
        setErrors(newErrors);

        return !Object.values(newErrors).some(error => error);
    }

    const handleLogin = () => {
        if (validateFields()) {
            console.log("OK")
        }
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value} = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));
    }

    const [showPassword, setShowPassword] = React.useState(false);

    const handleTogglePasswordVisibility = () => {
        setShowPassword((prev) => !prev);
    };

    return (
        <div className="w-full h-screen flex flex-col justify-center items-center p-[32px]">
            <div className="w-[90%] flex flex-col items-center gap-[24px]">
                <p className="text-3xl font-bold">Sign in</p>
                <div className="w-full flex flex-col gap-[8px]">
                    <TextField
                        onChange={handleChange}
                        margin="dense"
                        label="Email"
                        name="email"
                        type="text"
                        fullWidth
                        variant="outlined"
                        error={errors.email}
                        helperText={errors.email ? "Invalid email value!" : ""}
                    />
                    <div className="w-full flex flex-col items-end">
                        <TextField
                            onChange={handleChange}
                            margin="dense"
                            label="Password"
                            name="password"
                            type={showPassword ? "text" : "password"}
                            fullWidth
                            variant="outlined"
                            error={errors.password}
                            helperText={errors.password ? "Invalid password value!" : ""}
                            InputProps={{
                                endAdornment: (
                                    <InputAdornment position="end">
                                        <IconButton onClick={handleTogglePasswordVisibility} edge="end">
                                            {showPassword ? <VisibilityOff /> : <Visibility />}
                                        </IconButton>
                                    </InputAdornment>
                                ),
                            }}
                        />
                        <p className="text-md font-bold text-primary">Forgot Password?</p>
                    </div>
                </div>
                <Button
                    onClick={handleLogin}
                    variant="contained"
                    size="large"
                    fullWidth
                >LOGIN
                </Button>
                <Divider sx={{width: "100%"}}>OR</Divider>
                <div className="w-full flex items-center justify-center">
                    <p>Don't have account?</p>
                    <Link className="font-bold text-primary ml-[8px]" href="/register">Register</Link>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;