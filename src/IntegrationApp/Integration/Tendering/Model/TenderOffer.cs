using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration.Tendering.Model
{
    public class TenderOffer
    {
        [Key]
        public int Id { get; set; }
        public string TenderOfferInfo { get; set; }
        public int Price { get; set; }
        public int TenderId { get; set; }
        public bool IsAccepted { get; set; }
        public int DrugstoreId { get; set; }
        public bool IsActive { get; set; }

        public TenderOffer(){}

        public TenderOffer(int id, string offer,int price, int tenderId, bool isAccepted, int drugstoreId, bool isActive)
        {
            Id = id;
            TenderOfferInfo = offer;
            Price = price;
            TenderId = tenderId;
            IsAccepted = isAccepted;
            DrugstoreId = drugstoreId;
            IsActive = isActive;
        }
    }
}
