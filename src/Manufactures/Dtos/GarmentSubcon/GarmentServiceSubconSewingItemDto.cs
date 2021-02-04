﻿using System;
using System.Collections.Generic;
using Manufactures.Domain.GarmentSubcon.ServiceSubconSewings;
using Manufactures.Domain.Shared.ValueObjects;

namespace Manufactures.Dtos.GarmentSubcon
{
    public class GarmentServiceSubconSewingItemDto : BaseDto
    {
        public GarmentServiceSubconSewingItemDto(GarmentServiceSubconSewingItem garmentServiceSubconSewingItem)
        {
            Id = garmentServiceSubconSewingItem.Identity;
            ServiceSubconSewingId = garmentServiceSubconSewingItem.ServiceSubconSewingId;
            RONo = garmentServiceSubconSewingItem.RONo;
            Article = garmentServiceSubconSewingItem.Article;
            Comodity = new GarmentComodity(garmentServiceSubconSewingItem.ComodityId.Value, garmentServiceSubconSewingItem.ComodityCode, garmentServiceSubconSewingItem.ComodityName);
            
        }

        public Guid Id { get; set; }
        public Guid ServiceSubconSewingId { get; set; }
        public string RONo { get; set; }
        public string Article { get; set; }
        public GarmentComodity Comodity { get; set; }
    }
}
