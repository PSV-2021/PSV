export class DrugstoreOfferDto{
    Id: string;
    Title: string;
    Content:string;
    StartDate:Date;
    EndDate:Date;
    DrugstoreName: string;
    IsPublished:boolean;
    constructor(){
        this.Id = '';
        this.Content = '';
        this.Title = '';
        this.StartDate = Date.prototype;
        this.EndDate = Date.prototype;
        this.DrugstoreName = '';
        this.IsPublished = false;
    }
}