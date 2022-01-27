export class EventDto{
    public Id: number;
    public EventName: string;
    public EventTime: string;
    public EventId: number;
    constructor(){
        this.Id = 0,
        this.EventName = "",
        this.EventTime = "";
        this.EventId = 0;
    }
}