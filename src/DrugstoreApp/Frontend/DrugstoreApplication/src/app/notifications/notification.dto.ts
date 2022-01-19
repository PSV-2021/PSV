
export class NotificationDto{
    id: number;
    title: string;
    content: string;
    date: Date;
    recipients : string[];

    constructor(){
        this.id = 0;
        this.title = '';
        this.content = '';
        this.date = Date.prototype;
        this.recipients = [];
    }
}

