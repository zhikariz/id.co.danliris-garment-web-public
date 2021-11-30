﻿using ExtCore.Data.Abstractions;
using Infrastructure.Domain.Commands;
using Manufactures.Domain.GarmentSample.SampleRequests;
using Manufactures.Domain.GarmentSample.SampleRequests.Commands;
using Manufactures.Domain.GarmentSample.SampleRequests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Manufactures.Application.GarmentSample.SampleRequest.CommandHandler
{
    public class RemoveGarmentSampleRequestCommandHandler : ICommandHandler<RemoveGarmentSampleRequestCommand, GarmentSampleRequest>
    {
        private readonly IStorage _storage;
        private readonly IGarmentSampleRequestRepository _GarmentSampleRequestRepository;
        private readonly IGarmentSampleRequestProductRepository _GarmentSampleRequestProductRepository;
        private readonly IGarmentSampleRequestSpecificationRepository _garmentSampleRequestSpecificationRepository;

        public RemoveGarmentSampleRequestCommandHandler(IStorage storage)
        {
            _storage = storage;
            _GarmentSampleRequestRepository = storage.GetRepository<IGarmentSampleRequestRepository>();
            _GarmentSampleRequestProductRepository = storage.GetRepository<IGarmentSampleRequestProductRepository>();
            _garmentSampleRequestSpecificationRepository = storage.GetRepository<IGarmentSampleRequestSpecificationRepository>();
        }


        public async Task<GarmentSampleRequest> Handle(RemoveGarmentSampleRequestCommand request, CancellationToken cancellationToken)
        {
            var sampleRequest = _GarmentSampleRequestRepository.Query.Where(o => o.Identity == request.Identity).Select(o => new GarmentSampleRequest(o)).Single();

            _GarmentSampleRequestProductRepository.Find(o => o.SampleRequestId == sampleRequest.Identity).ForEach(async sampleProduct =>
            {
                sampleProduct.Remove();

                await _GarmentSampleRequestProductRepository.Update(sampleProduct);
            });

            _garmentSampleRequestSpecificationRepository.Find(o => o.SampleRequestId == sampleRequest.Identity).ForEach(async specification =>
            {
                specification.Remove();

                await _garmentSampleRequestSpecificationRepository.Update(specification);
            });

            sampleRequest.Remove();
            await _GarmentSampleRequestRepository.Update(sampleRequest);

            _storage.Save();

            return sampleRequest;
        }
    }
}