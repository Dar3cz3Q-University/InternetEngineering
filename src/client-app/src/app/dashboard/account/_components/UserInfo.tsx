import { UserType } from "@/types/user/UserType";
import { Avatar } from "@mui/material";

type PropType = {
    user: UserType | null;
}

const UserInfo = (props: PropType) => {
    const {
        user
    } = props;

    return (
        <div className="flex flex-row items-center">
            <Avatar 
                alt="User Avatar" 
                src={user?.imageUrl || ""}
            />
            <p className="ml-[8px] font-normal text-lg">{user?.firstName} {user?.lastName}</p>
        </div>
    )
}

export default UserInfo;