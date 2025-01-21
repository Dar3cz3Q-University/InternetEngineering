import Cookies from "js-cookie";

const isAuthenticated = () => {
    const isLoggedIn = Cookies.get("IsLoggedIn");

    return !!isLoggedIn;
}

export default isAuthenticated;
