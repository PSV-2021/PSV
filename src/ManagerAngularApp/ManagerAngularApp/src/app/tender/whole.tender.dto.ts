import { TenderDto } from "./tender.dto";

export class WholeTenderDto{
    id : string;
    tenderEnd: Date;
    tenderInfo: TenderDto[];

    constructor(){
        this.id = "";
        this.tenderEnd = Date.prototype;
        this.tenderInfo = [] as TenderDto[];
    }
}