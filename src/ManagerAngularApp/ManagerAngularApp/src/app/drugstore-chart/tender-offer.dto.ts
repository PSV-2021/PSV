import { TenderDto } from "../tender/tender.dto";

export class TenderOfferDto{

    drugstoreName: string;
    tenderInfo: TenderDto[];
    price: number;

    constructor(){
        this.drugstoreName = "";
        this.tenderInfo = [];
        this.price = 0;
        
    }
}