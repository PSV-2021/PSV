export class EventDto{
    public Id: number;
    public EventName: string;
    public EventTime: string;
    constructor(){
        this.Id = 0,
        this.EventName = "",
        this.EventTime = "";
    }
}