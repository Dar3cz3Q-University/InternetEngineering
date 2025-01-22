import { format } from "date-fns-tz";

const getUserTimezoneOffset = (): number => {
    return new Date().getTimezoneOffset() * -1.0;
};

const formatDate = (isoString: string): string => {
    const timezoneOffset = getUserTimezoneOffset();
    const date = new Date(isoString);
    date.setMinutes(date.getMinutes() + timezoneOffset);
    console.log(date);

    const day = String(date.getDate()).padStart(2, "0");
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
};

const formatTime = (isoString: string): string => {
    return format(isoString, "HH:mm");
    const timezoneOffset = getUserTimezoneOffset();
    console.log(timezoneOffset);
    const date = new Date(isoString);
    date.setMinutes(date.getMinutes() + timezoneOffset);

    const hours = String(date.getHours()).padStart(2, "0");
    const minutes = String(date.getMinutes()).padStart(2, "0");
    return `${hours}:${minutes}`;
};

const formatShortTime = (timeString: string): string => {
    return format(timeString, "HH:mm");
    const [hours, minutes] = timeString.split(":");
    return `${hours}:${minutes}`;
};

export { formatDate, formatTime, formatShortTime };
