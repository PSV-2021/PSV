import { TenderDto } from "./tender.dto";

export class WholeTenderDto{
    id : number;
    tenderEnd: Date;
    tenderInfo: TenderDto[];
    counterOfferInfo: TenderDto[];

    constructor(){
        this.id = 0;
        this.tenderEnd = Date.prototype;
        this.tenderInfo = [];
        this.counterOfferInfo = [];

    }
}