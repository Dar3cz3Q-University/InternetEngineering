import { IconButton, ListItem } from "@mui/material";
import DeleteIcon from '@mui/icons-material/Delete';

type PropType = {
    index: number;
    id: string;
    country: string;
    city: string;
    street: string;
    buildingNumber: string;
    apartmentNumber: string | null;
    latitude: number | null;
    longitude: number | null;
}

const AddressesListItem = (props: PropType) => {
    const {
        index,
        country,
        city,
        street,
        buildingNumber,
        apartmentNumber,
    } = props;

    return (
        <ListItem
            sx={{
                color: "var(--color-white)",
                padding: "16px 12px",
                display: "flex",
                flexDirection: "row",
                justifyContent: "space-between",
                backgroundColor: `${index % 2 == 0 ? "var(--color-secondary)" : "var(--color-gray)"}`,
                borderRadius: "16px"
            }}
        >
            <div className="flex flex-row justify-start">
                <p>{country}, {city} {street !== city ? street : ""} {buildingNumber}{apartmentNumber ? `/${apartmentNumber}` : ""}</p>
            </div>
            <div>
                <IconButton
                    size="small"
                >
                    <DeleteIcon
                        sx={{
                            color: "var(--color-white)"
                        }}
                    />
                </IconButton>
            </div>
        </ListItem>
    );
}

export default AddressesListItem;
