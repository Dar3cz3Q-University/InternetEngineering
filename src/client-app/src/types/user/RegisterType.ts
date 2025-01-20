export type RegisterType = {
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    userRole: number;
    avatarImage: File | null;
    maxSearchDistance: number;
}