export class ChartsInfoDto{
    DrugstoreId: number;
    DrugstoreName: string;
    wins: number;
    Profit: number;
    participations: number;

    constructor(){
        this.DrugstoreId = 0;
        this.DrugstoreName = "";
        this.wins = 0;
        this.Profit = 0;
        this.participations = 0;
    }
}