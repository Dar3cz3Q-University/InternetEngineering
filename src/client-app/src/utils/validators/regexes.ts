const isNonEmptyTextWithoutNumbersAndSpecialChars = (value: string): boolean => {
    const regex = /^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s]+$/u;
    return value.trim().length > 0 && regex.test(value.trim());
};

const isNonEmptyNonNegativeNumber = (value: string | null): boolean => {
    if (value === null)
        return true;
    const regex = /^\d+$/;
    return regex.test(value.trim());
};

const isNonNegativeNumberOrEmpty = (value: string): boolean => {
    const regex = /^\d+$/;
    return value.trim().length > 0 && regex.test(value.trim());
};

const isPostalCode = (value: string): boolean => {
    const regex = /^\d{2}-\d{3}$/;
    return regex.test(value.trim());
};

const isValidEmail = (value: string): boolean => {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(value.trim());
};

const isValidPassword = (value: string): boolean => {
    // Wymagania: Minimum 8 znaków, przynajmniej jedna duża litera, jedna cyfra i jeden znak specjalny
    const regex = /^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return regex.test(value.trim());
};

const isValidPhoneNumber = (value: string): boolean => {
    const regex = /^\d{9}$/;
    return regex.test(value.trim());
};


export {
    isNonEmptyNonNegativeNumber,
    isNonNegativeNumberOrEmpty,
    isNonEmptyTextWithoutNumbersAndSpecialChars,
    isPostalCode,
    isValidEmail,
    isValidPassword,
    isValidPhoneNumber
}