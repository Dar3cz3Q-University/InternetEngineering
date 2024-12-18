import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';

const CartBox = () => {

    //TODO: Handle cart routing

    return (
        <div className='flex items-center justify-center w-11 h-11 bg-c_secondary rounded-full box-content'>
            <ShoppingCartIcon className='w-5 h-5'/>
        </div>
    )
}

export default CartBox;