import { AppointmentScheduleProperties } from './appointmentScheduleProperties';
export class AppointmentEvent {
    public appointmentProperties : AppointmentScheduleProperties;
    public eventIdentificator : number;

    constructor(appointmentProperties : AppointmentScheduleProperties, eventIdentificator : number) {
        this.appointmentProperties = appointmentProperties;
        this.eventIdentificator = eventIdentificator;
    }
}