const formatDate = (isoString: string): string => {
    //ADD UTC +1
    const date = new Date(isoString);
    const day = String(date.getDate()).padStart(2, "0");
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
};

const formatTime = (isoString: string): string => {
    //ADD UTC +1
    const date = new Date(isoString);
    const hours = String(date.getHours()).padStart(2, "0");
    const minutes = String(date.getMinutes()).padStart(2, "0");
    return `${hours}:${minutes}`;
};

const formatShortTime = (timeString: string): string => {
    const [hours, minutes] = timeString.split(":");
    return `${hours}:${minutes}`;
};

export {formatDate, formatTime, formatShortTime};