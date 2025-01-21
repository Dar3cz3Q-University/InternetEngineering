import { IconButton } from "@mui/material"
import CheckIcon from '@mui/icons-material/Check';
import { useToast } from "@/components/contexts/ToastContext";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import changeDistanceRequest from "./_mutations/ChangeDistanceMutation";
import formatAxiosError from "@/utils/api/error-formatter";
import { useUser } from "@/components/contexts/UserContext";

const ApplyChangesButton = () => {
    const { user } = useUser();
    const { openToast } = useToast();
    const queryClient = useQueryClient();

    const { mutate } = useMutation({
        mutationFn: changeDistanceRequest,
        onSuccess: () => {
            openToast("Max search distance updated successfully.", "success");
            queryClient.invalidateQueries({ queryKey: ['user'] });
        },
        onError: (err: any) => {
            // TODO: Change any to error type
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
    });

    const handleDistanceUpdate = () => {
        if (user?.maxSearchDistance) {
            mutate(user?.maxSearchDistance);
        }
    }

    return (
        <IconButton
            onClick={handleDistanceUpdate}
            sx={{
                color: "var(--color-white)",
                backgroundColor: "var(--color-primary)",
                width: "38px",
                height: "38px",
                "&:hover": {
                    backgroundColor: "var(--color-primary)"
                }
            }}
        >
            <CheckIcon />
        </IconButton>
    )
}

export default ApplyChangesButton;
