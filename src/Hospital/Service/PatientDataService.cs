using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
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
