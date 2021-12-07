export class RecommendAppointmentDto {
    StartDate: string;
    EndDate: string;
    DoctorId: number;
    SpecializationId: number;
    Priority: number;

    constructor(){
        this.StartDate = "",
        this.EndDate = "",
        this.DoctorId = 0,
        this.SpecializationId = 0,
        this.Priority = 0
    }
}
