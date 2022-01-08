export class ChartsInfoDto{
    DrugstoreId: number;
    DrugstoreName: string;
    Wins: number;
    Profit: number;
    Participations: number;

    constructor(){
        this.DrugstoreId = 0;
        this.DrugstoreName = "";
        this.Wins = 0;
        this.Profit = 0;
        this.Participations = 0;
    }
}