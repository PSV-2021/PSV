using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Integration_API.DTOs;
using Integration.Model;

namespace Integration_API.Adapter
{
    public class DrugstoreAdapter
    {

        public static DrugstoreResponse ResponseDtoToResponse(PharmacyResponseDto dto)
        {
            DrugstoreResponse response = new DrugstoreResponse();

            response.DrugstoreId = 1;     

            response.Response = dto.Response;
            response.SentTime = DateTime.Now;
            response.RecievedTime = DateTime.Now;
            return response;
        }

    }
}
