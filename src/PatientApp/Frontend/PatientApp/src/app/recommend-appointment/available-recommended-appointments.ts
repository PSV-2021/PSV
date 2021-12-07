export class AvailableRecommendedAppointments {
    start : Date;
    end : Date;
    doctorId : number;
    doctorFullName : string;

    constructor() {
        this.start = new Date();
        this.end = new Date();
        this.doctorId = 0;
        this.doctorFullName = "";
    }
}
