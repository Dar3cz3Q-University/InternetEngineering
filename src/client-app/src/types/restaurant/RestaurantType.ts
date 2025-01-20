export type RestaurantType = {
    id: string;
    name: string;
    description?: string;
    imageUrl: string;
    distance: number;
    averageRate: number;
    ratesCount: number;
    isActive: boolean;
}