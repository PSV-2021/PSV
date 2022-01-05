import { WholeTenderDto } from "./whole.tender.dto";

export class TenderOfferDto{

    tender: WholeTenderDto;
    price: number;

    constructor(){
        this.tender = new WholeTenderDto;
        this.price = 0;
    }

}