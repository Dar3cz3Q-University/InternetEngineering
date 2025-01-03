import NavigateNextIcon from '@mui/icons-material/NavigateNext';
import Image from 'next/image';

type PropType = {
    id: number;
    imageUrl: string;
    title: string;
    description: string;
}

const Promotion: React.FC<PropType> = (props) => {
    const {id, imageUrl, title, description} = props;

    return (
        <div className="w-full flex flex-row justify-start items-center py-[12px]">
            <div className="relative flex-shrink-0 w-[84px] h-[84px] rounded-xl">
                <Image
                    src={imageUrl}
                    fill={true}
                    alt={`${title} image`}
                    className="rounded-xl object-cover"
                />
            </div>
            <div className="flex-1 h-full flex flex-col justify-start ml-[16px]">
                <p className="text-lg font-medium">{title}</p>
                <p className="opacity-70 leading-tight">{description}</p>
            </div>
            <div className="flex flex-col justify-center ml-[8px]">
                <NavigateNextIcon fontSize="large" sx={{color: "var(--color-gray)"}} />
            </div>
        </div>
    )
}

export default Promotion;