import { AddressType } from "@/types/common/AddressType";
import { getCurrentLocation } from "@/utils/location/get-current-location";
import { isNonEmptyNonNegativeNumber, isNonEmptyTextWithoutNumbersAndSpecialChars, isNonNegativeNumberOrEmpty, isPostalCode } from "@/utils/validators/regexes";
import { Button, TextField } from "@mui/material";
import React from "react";
import Map from "@/components/map";

type PropType = {
    onPrev: () => void;
    onNext: (data: Omit<AddressType, "id">) => void;
    locationData: Omit<AddressType, "id">;
}

const LocationForm = (props: PropType) => {
    const {onPrev, onNext, locationData} = props;
    const [formData, setFormData] = React.useState<Omit<AddressType, "id">>(locationData);

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

    const handleNext = () => {
        if (validateFields()) {
            onNext(formData);
        }
    }

    React.useEffect(() => {
        getCurrentLocation().then(({latitude, longitude}) => {
            setFormData(prev => ({
                ...prev,
                latitude,
                longitude
            }));
        });
    }, []);

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
        <>
            <div className="w-full flex flex-col gap-[8px]">
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
            </div>
            <div className="w-full flex flex-row justify-between gap-[16px]">
                <Button
                    onClick={onPrev}
                    variant="outlined"
                    size="large"
                    fullWidth
                >
                    BACK
                </Button>
                <Button
                    onClick={handleNext}
                    variant="contained"
                    size="large"
                    fullWidth
                >
                    NEXT
                </Button>
            </div>
        </>
    )
}

export default LocationForm;
