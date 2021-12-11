export class StandardAppointmentDto{
    PatientId: string;
    DoctorId: string;
    StartTime: string;

    constructor(){
        this.PatientId = "",
        this.DoctorId = "",
        this.StartTime = ""
    }
}
