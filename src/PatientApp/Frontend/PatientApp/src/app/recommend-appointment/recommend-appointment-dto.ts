export class RecommendAppointmentDto {
    StartInterval: String;
    EndInterval: String;
    DoctorId: number;
    SpecializationId: number;
    Priority: number;

    constructor(){
        this.StartInterval = "",
        this.EndInterval = "",
        this.DoctorId = 0,
        this.SpecializationId = 0,
        this.Priority = 0
    }
}
