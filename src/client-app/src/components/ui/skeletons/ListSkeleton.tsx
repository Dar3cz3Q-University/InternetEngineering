import { Skeleton } from "@mui/material";

const ListSkeleton = () => {
    return (
        <>
        {
            Array.from({length: 5}).map((_, index) => (
                <div key={index} className="w-full flex flex-col gap-[32px] shadow-lg">
                    <Skeleton
                        variant="rectangular"
                        height={100}
                        width="100%"
                    />
                    <Skeleton variant="text" width="60%" />
                    <Skeleton variant="text" width="80%" />
                </div>
            ))
        }
        </>
    )
}

export default ListSkeleton;