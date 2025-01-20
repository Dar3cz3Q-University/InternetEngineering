import { SectionType } from "./SectionType";

export type MenuType = {
    id: string;
    sections: SectionType[];
    createdDateTime?: string;
    updatedDateTime?: string;
}