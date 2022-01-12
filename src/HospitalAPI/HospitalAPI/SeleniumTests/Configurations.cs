using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests
{
    static class Configurations
    {
        public static string HostPatient
        {
            get => Environment.GetEnvironmentVariable("PF_HOST") ?? "http://localhost:4200";
        }

        public static string HostManager
        {
            get => Environment.GetEnvironmentVariable("MF_HOST") ?? "http://localhost:3001";
        }

        public static string CommentsUrl
        {
            get => HostPatient + "/comments";
        }

        public static string FeedbacksUrl
        {
            get => HostManager + "/feedbacks";
        }

        public static string LoginUrl
        {
            get => HostPatient + "/login";
        }

        public static string MedicalRecordUrl
        {
            get => HostPatient + "/medicalRecord";
        }

    }
}
