
export class NotificationDto{
    id: number;
    drugstoreName: string;
    title: string;
    content: string;
    date: Date;
    isRead : boolean;

    constructor(){
        this.id = 0;
        this.drugstoreName = '';
        this.title = '';
        this.content = '';
        this.date = Date.prototype;
        this.isRead = false;
    }
}

