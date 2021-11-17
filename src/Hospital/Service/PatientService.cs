using Model;
using System;
using System.Collections.Generic;

using Repository;
using System.Threading;

namespace Service
{
   public class PatientService
    {
        private IPatientRepository PatientRepository { get; }

        public PatientService(IPatientRepository @object, object p)
        {
            PatientRepository = new PatientFileRepository();
        }

        public PatientService()
        {
        }

        public Patient GetPatientByJmbg(string jmbg)
        {
            return PatientRepository.GetOne(jmbg);
        }

        public List<Patient> GetAllPatients()
        {
            return PatientRepository.GetAll();
        }
        public Boolean SavePatient(Patient newPatient)
        {
            return PatientRepository.Save(newPatient);
        }

        public Boolean EditPatient(Patient editedPatient)
        {
            return PatientRepository.Update(editedPatient);
        }

        public Boolean DeletePatient(string jmbg)
        {
            return PatientRepository.Delete(jmbg);
        }

        public void UnblockPatient(string jmbg)
        {
            Patient blockedPatient = PatientRepository.GetOne(jmbg);
            blockedPatient.IsBlocked = false;
            PatientRepository.Update(blockedPatient);
        }

        
        public Patient LoadPatient()
        {
            Patient patient = PatientRepository.GetOne("1008985563244");
            return patient;
        }

        //public void MedicineNotification()
        //{
        //    while (true)
        //    {
        //        foreach (Prescription p in PatientView.Patient.MedicalRecord.prescription)
        //        {
        //            GenerateNotification(p);
        //        }
        //        Thread.Sleep(TimeSpan.FromMinutes(5));
        //    }
        //}
        /*
        public List<DateTime> GenerateNotification(Prescription prescription)
        {
            List<DateTime> notifications = AddTimeToSpan(prescription);
            foreach (DateTime dt in notifications)
            {
                if (CanShowNotification(dt))
                {
                    PatientNotification noti = new PatientNotification("Podsetnik da lek " + prescription.Medicine.Name + "trebate popiti u " + dt.ToString("HH:mm"));
                    noti.Show();
                }
            }
            return notifications;
        }
        */

        private Boolean CanShowNotification(DateTime dateTime)
        {
            if (dateTime >= DateTime.Now && dateTime <= DateTime.Now.AddMinutes(5))
            {
                return true;
            }
            return false;
        }

        private List<DateTime> AddTimeToSpan(Prescription prescription)
        {
            DateTime it = new DateTime();
            it = prescription.StartDate.AddSeconds(0);
            DateTime start = prescription.StartDate;
            DateTime end = prescription.StartDate.AddDays(prescription.DurationInDays);
            List<DateTime> notifications = new List<DateTime>();

            while (it.Date < end.Date)
            {
                if (PeriodDaily(prescription))
                {
                    for (int i = 0; i < prescription.Number; i++)
                    {
                        notifications.Add(start.AddHours(i * 24 / prescription.Number));
                    }
                    it = it.AddDays(1);
                }
                else
                {
                    for (int i = 0; i < prescription.Number; i++)
                    {
                        notifications.Add(start.AddDays(i * 7 / prescription.Number));
                    }
                    it = it.AddDays(7);
                }
            }
            return notifications;
        }

        public Patient Save(Patient patient)
        {
            throw new NotImplementedException();
        }

        private Boolean PeriodDaily(Prescription prescription)
        {
            if (prescription.ReferencePeriod == Period.daily)
                return true;
            return false;
        }

        public void AddPrescriptionToPatient(Patient patient, Prescription newPrescription)
        {
            patient.MedicalRecord.AddPrescription(newPrescription);
            EditPatient(patient);
        }

        public void AddAnamnesisToPatient(Patient patient, Anamnesis newAnamnesis)
        {
            patient.MedicalRecord.AddAnamnesis(newAnamnesis);
            EditPatient(patient);
        }

        public void AddReferralLetterToPatient(Patient patient, ReferralLetter newReferralLetter)
        {
            patient.MedicalRecord.AddReferralLetter(newReferralLetter);
            EditPatient(patient);
        }

        public void AddHospitalTreatmentToPatient(Patient patient, HospitalTreatment newHospitalTreatment)
        {
            patient.MedicalRecord.AddHospitalTreatment(newHospitalTreatment);
            EditPatient(patient);
        }

        public void RemovePrescriptionFromPatient(Patient patient, Prescription prescription)
        {
            patient.MedicalRecord.RemovePrescription(prescription);
            EditPatient(patient);
        }

        public void RemoveReferralLetterFromPatient(Patient patient, ReferralLetter referralLetter)
        {
            patient.MedicalRecord.RemoveReferralLetter(referralLetter);
            EditPatient(patient);
        }

        public void RemoveHospitalTreatmentFromPatient(Patient patient, HospitalTreatment hospitalTreatment)
        {
            patient.MedicalRecord.RemoveHospitalTreatment(hospitalTreatment);
            EditPatient(patient);
        }

        public void RemoveAnamnesisFromPatient(Patient patient, Anamnesis anamnesis)
        {
            patient.MedicalRecord.RemoveAnamnesis(anamnesis);
            EditPatient(patient);
        }

        public List<MedicineCount> GetMedicineCountForSelectedDate(DateTime startDate, DateTime endDate)
        {
            Dictionary<int, int> medicineCount = CreateMedicineCountDictionary(startDate, endDate);

            var medicineService = new MedicineService(new MedicineFileRepository());
            List<MedicineCount> medicineTotals = new List<MedicineCount>();
            foreach (var temp in medicineCount) {
                var medicineId = temp.Key;
                var medicine = medicineService.getMedicineById(medicineId);
                var count = temp.Value;
                var medicineTotal = new MedicineCount(medicine, count);
                medicineTotals.Add(medicineTotal);
            }
            return medicineTotals;
        }

        private Dictionary<int, int> CreateMedicineCountDictionary(DateTime startDate, DateTime endDate)
        {
            List<Patient> allPatients = GetAllPatients();
            Dictionary<int, int> medicineCount = new Dictionary<int, int>();
            foreach (var patient in allPatients)
            {
                var medicalRecord = patient.MedicalRecord;
                var allPrescriptions = medicalRecord.Prescription;
                foreach (var prescription in allPrescriptions)
                {
                    if (IsPrescriptionInTimeInterval(prescription, startDate, endDate))
                    {
                        var medicineId = prescription.Medicine.MedicineID;
                        if (medicineCount.ContainsKey(medicineId))
                            medicineCount[medicineId] += 1;
                        else
                            medicineCount[medicineId] = 1;
                    }
                }
            }
            return medicineCount;
        }

        private Boolean IsPrescriptionInTimeInterval(Prescription prescription, DateTime startDate, DateTime endDate)
        {
            var prescriptionStartDate = prescription.StartDate;
            var prescriptionEndDate = prescriptionStartDate.AddDays(prescription.DurationInDays);
            return DateTime.Compare(prescriptionEndDate, startDate) > 0 && DateTime.Compare(prescriptionStartDate, endDate) < 0;
        }

        public int GetMedicineCountSum(List<MedicineCount> medicineCount)
        {
            int sum = 0;
            foreach(var med in medicineCount)
            {
                sum += med.Count;
            }
            return sum;
        }

        
    }

}
