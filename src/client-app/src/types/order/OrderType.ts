export type OrderType = {
    id: string;
    restaurantName: string;
    imageUrl: string;
    orderStatus: string;
    isActive: boolean;
    createdDateTime: string;
    updatedDateTime?: string;
}