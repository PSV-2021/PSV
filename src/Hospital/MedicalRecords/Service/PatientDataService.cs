using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hospital.MedicalRecords.Service
{
    public class PatientDataService
    {
        private readonly HttpClient _http;
        public PatientDataService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }
        public Task<String> GetStringAsync(Uri url)
        {
            return _http.GetStringAsync(url);
        }

        public Task<HttpResponseMessage> GetSomethingRemoteAsync(String v)
        {
            return _http.PostAsync(v, null);
        }
    }
}
