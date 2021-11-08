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
        //public static Model.
        public static DrugstoreResponse ResponseDtoToResponse(PharmacyResponseDto dto)
        {
            DrugstoreResponse response = new DrugstoreResponse();

            response.DrugstoreId = 1; //temporary 
           // response.Id = dto.id;          

            response.Response = dto.Response;
            response.SentTime = DateTime.Now;
            response.RecievedTime = DateTime.Now;
            return response;
        }

        //public static ProductDto ProductToProductDto(Product product)
        //{
        //    ProductDto dto = new ProductDto();
        //    dto.Name = product.Name;
        //    dto.Color = product.Color;
        //    dto.Price = product.Price;
        //    dto.CategoryId = product.Category.Id;
        //    return dto;
        //}
    }
}
