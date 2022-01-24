using Hospital.PatientEvent.Model;
using Hospital.PatientEvent.Repository.Interface;
using Hospital.PatientEvent.Repository.Sql;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.PatientEvent.Service
{
    public class EventService
    {
        public IEventRepository EventRepository { get; set; }
        public readonly MyDbContext dbContext;
        public EventService(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        public EventService(MyDbContext context)
        {
            this.dbContext = context;
            EventRepository = new EventSqlRepository(context);
        }

        public List<Event> GetAll()
        {
            return EventRepository.GetAll();
        }

        public Event GetOne(int id)
        {
            return EventRepository.GetById(id);
        }

        public void Save(Event e)
        {
            EventRepository.Save(e);
        }

        public List<double> GetPercentSuccessfullAndQuit()
        {
            List<double> result = new List<double>();

            List<Event> allSuccessfull = EventRepository.GetAllSuccessful();
            List<Event> allFirstStep = EventRepository.GetAllFirstStep();
            List<Event> allThirdStep = EventRepository.GetAllThirdStep();
            List<Event> allQuit = EventRepository.GetAllQuit();

            int allAppointments = allSuccessfull.Count + allQuit.Count;

            double successfullPercent = (double)allSuccessfull.Count / (double)allAppointments * 100;
            double successfullFirstStep = (double)allFirstStep.Count / (double)allAppointments * 100;
            double successfullThirdStep = (double)allThirdStep.Count / (double)allAppointments * 100;
            double quitPercent = (double)allQuit.Count / (double)allAppointments * 100;

            result.Add(successfullPercent);
            result.Add(successfullFirstStep);
            result.Add(successfullThirdStep);
            result.Add(quitPercent);

            return result;
        }
    }
}
