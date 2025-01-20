import { CartItemType } from "@/types/cart/CartItemType";
import { CartType } from "@/types/cart/CartType";
import { RestaurantCartType } from "@/types/cart/RestaurantCartType";
import Cookies from "js-cookie"

const COOKIE_NAME = "cart";

export const addToCart = (restaurantId: string, restaurantName: string, item: CartItemType): void => {
    const cart: CartType = getCart();

    if(!cart[restaurantId]) {
        cart[restaurantId] = {restaurantName, items: []};
    }

    const existingItemIndex = cart[restaurantId].items.findIndex((cartItem: CartItemType) => cartItem.id === item.id);

    if (existingItemIndex !== -1) {
        cart[restaurantId].items[existingItemIndex].quantity += 1;
    }
    else {
        cart[restaurantId].items.push(item);
    }

    Cookies.set(COOKIE_NAME, JSON.stringify(cart), {expires: 1});

    const event = new CustomEvent("cartUpdated");
    window.dispatchEvent(event);
}

export const getCart = (): CartType => {
    const cart = Cookies.get(COOKIE_NAME);

    if (!cart) {
        return {};
    }

    try {
        return JSON.parse(cart) as CartType;
    }
    catch (error) {
        console.error("Error parsing cart cookie: ", error);
        return {}
    }
};

export const getRestaurantItemsCount = (restaurant: string): number => {
    const cart = getCart();

    if (!cart[restaurant]) {
        return 0;
    }

    return cart[restaurant].items.reduce((total, item) => total + item.quantity, 0);
}

export const removeRestaurantCart = (restaurantId: string): void => {
    const cart = getCart();

    if (cart[restaurantId]) {
        delete cart[restaurantId];
        Cookies.set(COOKIE_NAME, JSON.stringify(cart), { expires: 1 });
    }
};

export const getRestaurantCart = (restaurantId: string | null): RestaurantCartType | null => {
    if (restaurantId === null) {
        return null;
    }

    const cart = getCart();

    if (!cart[restaurantId]) {
        return null;
    }

    return cart[restaurantId];
};