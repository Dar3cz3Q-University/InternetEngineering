// TODO: Change any to error type
const formatAxiosError = (error: any): string => {
    return error?.response?.data?.title ?? "Internal server error.";
}

export default formatAxiosError;
