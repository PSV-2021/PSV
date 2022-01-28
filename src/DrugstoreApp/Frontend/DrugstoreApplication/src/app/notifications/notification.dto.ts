
export class NotificationDto{
    id: number;
    hospitalName: string;
    title: string;
    content: string;
    date: Date;
    isRead: boolean;

    constructor(){
        this.id = 0;
        this.hospitalName = '';
        this.title = '';
        this.content = '';
        this.date = Date.prototype;
        this.isRead = false;
    }

}

