import { ThisReceiver, ThrowStmt } from "@angular/compiler";

export class DrugstoreOfferDto{
    Id: string;
    Title: string;
    Content:string;
    StartDate:Date;
    EndDate:Date;
    DrugstoreName: string;
    constructor(){
        this.Id = '';
        this.Title = '';
        this.Content = '';
        this.DrugstoreName = '';
        this.StartDate = Date.prototype;
        this.EndDate = Date.prototype;
    }
}


