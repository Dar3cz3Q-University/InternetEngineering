import Map from "@/components/map";
import { AddressType } from "@/types/common/AddressType";
import { getCurrentLocation } from "@/utils/location/get-current-location";
import { isNonEmptyNonNegativeNumber, isNonEmptyTextWithoutNumbersAndSpecialChars, isNonNegativeNumberOrEmpty, isPostalCode } from "@/utils/validators/regexes";
import {Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField} from "@mui/material"
import React from "react";

type PropType = {
    open: boolean;
    handleClose: () => void;
    handleAdd: (newAddress: Omit<AddressType, "id">) => void;
}

const AddAddressDialog = (props: PropType) => {
    const {
        open,
        handleClose,
        handleAdd
    } = props;

    const [formData, setFormData] = React.useState<Omit<AddressType, "id">>({
        country: "",
        state: "",
        city: "",
        street: "",
        buildingNumber: "",
        apartmentNumber: null,
        postalCode: "",
        longitude: 0,
        latitude: 0
    })

    const [errors, setErrors] = React.useState({
        country: false,
        state: false,
        city: false,
        street: false,
        buildingNumber: false,
        apartmentNumber: false,
        postalCode: false,
    })

    const validateFields = () => {
        const newErrors = {
            country: !isNonEmptyTextWithoutNumbersAndSpecialChars(formData.country),
            state: !isNonEmptyTextWithoutNumbersAndSpecialChars(formData.state),
            city: !isNonEmptyTextWithoutNumbersAndSpecialChars(formData.city),
            street: !isNonEmptyTextWithoutNumbersAndSpecialChars(formData.street),
            buildingNumber: !isNonNegativeNumberOrEmpty(formData.buildingNumber),
            apartmentNumber: !isNonEmptyNonNegativeNumber(formData.apartmentNumber),
            postalCode: !isPostalCode(formData.postalCode)
        }
        setErrors(newErrors);
        return !Object.values(newErrors).some(error => error);
    }

    const handleSave = () => {
        if (validateFields()) {
            handleAdd(formData);
            handleClose();
        }
    }

    React.useEffect(() => {
        if (open) {
            getCurrentLocation().then(({latitude, longitude}) => {
                setFormData(prev => ({
                    ...prev,
                    latitude,
                    longitude
                }));
            });
        }
    }, [open]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value} = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: name === "apartmentNumber" && value === "" ? null : value
        }));
    }

    const handleMapClick = (latitude: number, longitude: number) => {
        setFormData((prev) => ({
            ...prev,
            longitude,
            latitude
        }))
    }

    return (
        <Dialog
            open={open}
            onClose={handleClose}
        >
            <DialogTitle>Add New Address</DialogTitle>
            <DialogContent>
            <TextField
                    margin="dense"
                    label="Country"
                    name="country"
                    type="text"
                    fullWidth
                    variant="outlined"
                    value={formData.country}
                    onChange={handleChange}
                    error={errors.country}
                    helperText={errors.country ? "Invalid value!" : ""}
                />
                <TextField
                    margin="dense"
                    label="State"
                    name="state"
                    type="text"
                    fullWidth
                    variant="outlined"
                    value={formData.state}
                    onChange={handleChange}
                    error={errors.state}
                    helperText={errors.state ? "Invalid value!" : ""}
                />
                <TextField
                    margin="dense"
                    label="City"
                    name="city"
                    type="text"
                    fullWidth
                    variant="outlined"
                    value={formData.city}
                    onChange={handleChange}
                    error={errors.city}
                    helperText={errors.city ? "Invalid value!" : ""}
                />
                <TextField
                    margin="dense"
                    label="Street"
                    name="street"
                    type="text"
                    fullWidth
                    variant="outlined"
                    value={formData.street}
                    onChange={handleChange}
                    error={errors.street}
                    helperText={errors.street ? "Invalid value!" : ""}
                />
                <div className="w-full flex flex-row gap-[12px]">
                    <TextField
                        margin="dense"
                        label="Building Number"
                        name="buildingNumber"
                        type="text"
                        variant="outlined"
                        value={formData.buildingNumber}
                        onChange={handleChange}
                        error={errors.buildingNumber}
                        helperText={errors.buildingNumber ? "Invalid value!" : ""}
                    />
                    <TextField
                        margin="dense"
                        label="Apartment Number"
                        name="apartmentNumber"
                        type="text"
                        variant="outlined"
                        value={formData.apartmentNumber || ""}
                        onChange={handleChange}
                        error={errors.apartmentNumber}
                        helperText={errors.apartmentNumber ? "Invalid value!" : ""}
                    />
                </div>
                <TextField
                    margin="dense"
                    label="Postal Code (XX-XXX)"
                    name="postalCode"
                    type="text"
                    fullWidth
                    variant="outlined"
                    value={formData.postalCode}
                    onChange={handleChange}
                    error={errors.postalCode}
                    helperText={errors.postalCode ? "Invalid value!" : ""}
                />
                <div className="w-full h-[250px] mt-[8px]">
                    <Map
                        latitude={formData.latitude}
                        longitude={formData.longitude}
                        onMapClick={handleMapClick}
                    />
                </div>
                
            </DialogContent>
            <DialogActions>
                    <Button onClick={handleClose} color="primary">
                        Cancel
                    </Button>
                    <Button onClick={handleSave} color="primary" variant="contained">
                        Add Address
                    </Button>
                </DialogActions>
        </Dialog>
    )
}

export default AddAddressDialog;