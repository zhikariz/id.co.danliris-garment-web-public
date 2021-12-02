﻿using Infrastructure.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Domain.GarmentSample.SampleRequests.ReadModels
{
    public class GarmentSampleRequestReadModel : ReadModelBase
    {
        public GarmentSampleRequestReadModel(Guid identity) : base(identity)
        {
        }

        public string SampleCategory { get; internal set; }
        public string SampleRequestNo { get; internal set; }
        public string RONoSample { get; internal set; }
        public string RONoCC { get; internal set; }
        public DateTimeOffset Date { get; internal set; }

        public int BuyerId { get; internal set; }
        public string BuyerCode { get; internal set; }
        public string BuyerName { get; internal set; }

        public int ComodityId { get; internal set; }
        public string ComodityCode { get; internal set; }
        public string ComodityName { get; internal set; }

        public string SampleType { get; internal set; }
        public string Packing { get; internal set; }
        public DateTimeOffset SentDate { get; internal set; }
        public string POBuyer { get; internal set; }
        public string Attached { get; internal set; }
        public string Remark { get; internal set; }
        public bool IsPosted { get; internal set; }
        public bool IsReceived { get; internal set; }
        public DateTimeOffset? ReceivedDate { get; internal set; }
        public string ReceivedBy { get; internal set; }

        public virtual List<GarmentSampleRequestProductReadModel> SampleProduct { get; internal set; }
        public virtual List<GarmentSampleRequestSpecificationReadModel> SampleSpecification { get; internal set; }
    }
}