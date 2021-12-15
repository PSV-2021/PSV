using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class PublishedOfferDto
    {
        public String OfferId { get; set; }

        public PublishedOfferDto( string offerId)
        {

            this.OfferId = offerId;
        }

        public PublishedOfferDto()
        {

        }

    }
}
