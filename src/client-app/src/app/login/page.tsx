"use client";

import { useToast } from "@/components/contexts/ToastContext";
import { LoginType } from "@/types/user/LoginType";
import { isValidEmail, isValidPassword } from "@/utils/validators/regexes";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { Button, Divider, IconButton, InputAdornment, Link, TextField } from "@mui/material";
import { useMutation } from "@tanstack/react-query";
import React from "react";
import loginRequest from "./_mutations/LoginMutation";
import { UserType } from "@/types/user/UserType";
import { useUser } from "@/components/contexts/UserContext";
import formatAxiosError from "@/utils/api/error-formatter";
import { AxiosError } from "axios";

const LoginPage = () => {
    const { login } = useUser();
    const { openToast } = useToast();

    const [formData, setFormData] = React.useState<LoginType>({
        email: "",
        password: ""
    });

    const [errors, setErrors] = React.useState({
        email: false,
        password: false,
        invalidUserData: false
    });

    const { mutate } = useMutation({
        mutationFn: loginRequest,
        onSuccess: (res: UserType) => {
            login(res);
        },
        onError: (err: AxiosError) => {
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
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
            mutate(formData);
        }
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
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
                <Divider sx={{ width: "100%" }}>OR</Divider>
                <div className="w-full flex items-center justify-center">
                    <p>Don&apos;t have account?</p>
                    <Link className="font-bold text-primary ml-[8px]" href="/register">Register</Link>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;
