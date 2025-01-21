"use client";

import { RegisterType } from "@/types/user/RegisterType";
import { RegisterUserType } from "@/types/user/RegisterUserType";
import { isValidEmail, isValidPassword, isNonEmptyTextWithoutNumbersAndSpecialChars, isValidPhoneNumber } from "@/utils/validators/regexes";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { Button, Checkbox, FormControlLabel, IconButton, InputAdornment, TextField } from "@mui/material";
import React from "react";

type PropType = {
    userData: Omit<RegisterUserType, "address">;
    onNext: (data: Omit<RegisterUserType, "address">) => void;
}

const UserForm = (props: PropType) => {
    const { userData, onNext } = props;
    const [formData, setFormData] = React.useState<Omit<RegisterUserType, "address">>(userData);

    const [errors, setErrors] = React.useState({
        email: false,
        password: false,
        firstName: false,
        lastName: false,
        phoneNumber: false,
    })

    const validateFields = () => {
        const newErrors = {
            email: !isValidEmail(formData.email),
            password: !isValidPassword(formData.password),
            firstName: !isNonEmptyTextWithoutNumbersAndSpecialChars(formData.firstName),
            lastName: !isNonEmptyTextWithoutNumbersAndSpecialChars(formData.lastName),
            phoneNumber: !isValidPhoneNumber(formData.phoneNumber),
        }
        setErrors(newErrors);

        return !Object.values(newErrors).some(error => error);
    }

    const handleNext = () => {
        if (validateFields()) {
            onNext(formData);
        }
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));
    }

    const handleRoleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData((prev) => ({
            ...prev,
            userRole: e.target.checked ? 2 : 1
        }));
    };

    const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0] || null;
        setFormData((prev) => ({
            ...prev,
            image: file,
        }));
    };

    const [showPassword, setShowPassword] = React.useState(false);
    const handleTogglePasswordVisibility = () => {
        setShowPassword((prev) => !prev);
    };

    return (
        <>
            <div className="w-full flex flex-col gap-[8px]">
                <TextField
                    value={formData.email}
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
                <TextField
                    value={formData.password}
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
                <div className="w-full flex flex-row justify-between gap-[16px]">
                    <TextField
                        value={formData.firstName}
                        onChange={handleChange}
                        margin="dense"
                        label="First Name"
                        name="firstName"
                        type="text"
                        fullWidth
                        variant="outlined"
                        error={errors.firstName}
                        helperText={errors.firstName ? "Invalid value!" : ""}
                    />
                    <TextField
                        value={formData.lastName}
                        onChange={handleChange}
                        margin="dense"
                        label="Last Name"
                        name="lastName"
                        type="text"
                        fullWidth
                        variant="outlined"
                        error={errors.lastName}
                        helperText={errors.lastName ? "Invalid value!" : ""}
                    />
                </div>
                <TextField
                    value={formData.phoneNumber}
                    onChange={handleChange}
                    margin="dense"
                    label="Phone Number"
                    name="phoneNumber"
                    type="text"
                    fullWidth
                    variant="outlined"
                    error={errors.phoneNumber}
                    helperText={errors.phoneNumber ? "Invalid value!" : ""}
                />
                <div className="w-full mt-[8px]">
                    <Button
                        variant="outlined"
                        component="label"
                        size="large"
                        fullWidth
                    >
                        Upload Avatar
                        <input
                            type="file"
                            accept="image/*"
                            hidden
                            onChange={handleFileChange}
                        />
                    </Button>
                    {formData.image && (
                        <p className="text-sm mt-2">Selected file: {formData.image.name}</p>
                    )}
                </div>
                <FormControlLabel
                    control={
                        <Checkbox
                            checked={formData.userRole === 2}
                            onChange={handleRoleChange}
                            color="primary"
                        />
                    }
                    label="Create courier account"
                />
            </div>
            <Button
                onClick={handleNext}
                variant="contained"
                size="large"
                fullWidth
            >NEXT
            </Button>
        </>
    )
}

export default UserForm;
