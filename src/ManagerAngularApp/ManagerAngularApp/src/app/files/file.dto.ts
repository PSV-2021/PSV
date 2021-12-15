export class FileDto{
    Name: string;
    Downloaded: boolean;
    isNew: boolean;

    constructor(){
        this.Name = "";
        this.Downloaded = false ; 
        this.isNew = false;
    }
}