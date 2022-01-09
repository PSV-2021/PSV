export class AvailableRecommendedAppointments {
    start : Date;
    doctorId : number;
    doctorFullName: string;

    constructor() {
        this.start = new Date();
        this.doctorId = 0;
        this.doctorFullName = "";
    }
}
