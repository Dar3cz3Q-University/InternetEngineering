import PlaceIcon from '@mui/icons-material/Place';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';

const LocationBox = () => {

    //TODO: Location getter

    return (
        <div className='flex flex-col'>
            <p className="text-t_gray text-sm ml-1">Your location</p>
            <div className='flex flex-row items-center justify-start'>
                <PlaceIcon fontSize='small'className='text-c_primary'/>
                <p className='ml-1 font-light'>Kraków, Na Błonie 11</p>
                <KeyboardArrowDownIcon className='ml-1'/>
            </div>
            
        </div>
    )
}

export default LocationBox;