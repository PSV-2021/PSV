﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Dtos
{
    public class HospitalDto
    {
        public string HospitalName { get; set; }
        public string URLAddress { get; set; }
        public string ApiKey { get; set; }

        public HospitalDto(string name, string url, string apiKey)
        {
            this.HospitalName = name;
            this.URLAddress = url;
            this.ApiKey = apiKey;
        }
    }
}