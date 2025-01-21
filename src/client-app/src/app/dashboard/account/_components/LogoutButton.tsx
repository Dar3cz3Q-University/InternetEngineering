import { Button } from "@mui/material";
import { useMutation } from "@tanstack/react-query";
import logoutRequest from "./_mutations/LogoutMutation";
import { useToast } from "@/components/contexts/ToastContext";
import formatAxiosError from "@/utils/api/error-formatter";
import { useRouter } from "next/navigation";
import { useUser } from "@/components/contexts/UserContext";

const LogoutButton = () => {
    const { setUser } = useUser();
    const { openToast } = useToast();
    const router = useRouter();

    const { mutate } = useMutation({
        mutationFn: logoutRequest,
        onError: (err: any) => {
            // TODO: Change any to error type
            const message = formatAxiosError(err);
            openToast(message, "error");
        }
    });

    const handleLogout = () => {
        mutate();
        setUser(null);
        router.push("/login");
    }

    return (
        <div className="w-full px-[32px] fixed bottom-[88px] left-0">
            <Button
                onClick={handleLogout}
                fullWidth
                variant="outlined"
                size="large"
                color="error"
            >
                LOGOUT
            </Button>
        </div>
    )
}

export default LogoutButton;
