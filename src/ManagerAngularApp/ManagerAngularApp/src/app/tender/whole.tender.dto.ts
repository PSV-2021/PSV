import { TenderDto } from "./tender.dto";

export class WholeTenderDto{

    tenderEnd: Date;
    tenderInfo: TenderDto[];

    constructor(){
        this.tenderEnd = Date.prototype;
        this.tenderInfo = [] as TenderDto[];
    }
}