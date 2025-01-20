type PropType = {
    city: string;
    street: string;
    buildingNumber: string;
    apartmentNumber: string | null;
}

const DeliveryAddressInfo = (props: PropType) => {
    const {
        city,
        street,
        buildingNumber,
        apartmentNumber
    } = props;

    return (
        <div className="w-full mt-[16px]">
            <p className="text-lg font-semibold">Delivery address:</p>
            <p>City: <span className="font-semibold">{city}</span></p>
            {street !== city ? <p>Street: <span className="font-semibold">{street}</span></p> : null}
            <p>House number: <span className="font-semibold">{buildingNumber}</span></p>
            {apartmentNumber ? <p>Flat number: <span className="font-semibold">{apartmentNumber}</span></p> : null}
        </div>
    )
}

export default DeliveryAddressInfo;