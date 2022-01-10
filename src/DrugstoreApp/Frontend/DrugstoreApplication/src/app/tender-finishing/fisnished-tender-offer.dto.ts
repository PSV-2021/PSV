import { TenderDto } from "../tenders/tender.dto";

export class FinishedTenderOfferDto{
    id : string;
    tenderEnd: Date;
    tenderInfo: TenderDto[];
    counterOfferInfo: TenderDto[];
    isWinner : boolean;

    constructor(){
        this.id = "";
        this.tenderEnd = Date.prototype;
        this.tenderInfo = [];
        this.counterOfferInfo = [];
        this.isWinner = false;

    }
}