using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class NewPharmacyReviewDto
    {
        public int pharmacyId { get; set; }
        public string review { get; set; }

        public NewPharmacyReviewDto(int pharmacyId, string review)
        {
            this.pharmacyId = pharmacyId;
            this.review = review;
        }

        public NewPharmacyReviewDto()
        {

        }

    }
}
