﻿using FluentValidation;
using Infrastructure.Domain.Commands;
using Manufactures.Domain.GarmentSubcon.ServiceSubconCuttings.ValueObjects;
using Manufactures.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manufactures.Domain.GarmentSubcon.ServiceSubconCuttings.Commands
{
    public class UpdateGarmentServiceSubconCuttingCommand : ICommand<GarmentServiceSubconCutting>
    {
        public Guid Identity { get; private set; }
        public string RONo { get; set; }
        public string Article { get; set; }
        public UnitDepartment Unit { get; set; }
        public DateTimeOffset? SubconDate { get; set; }
        public string SubconNo { get; set; }
        public string SubconType { get; set; }
        public GarmentComodity Comodity { get; set; }

        public bool IsUsed { get; set; }
        public List<GarmentServiceSubconCuttingItemValueObject> Items { get; set; }

        public void SetIdentity(Guid id)
        {
            Identity = id;
        }
    }

    public class UpdateGarmentServiceSubconCuttingCommandValidator : AbstractValidator<UpdateGarmentServiceSubconCuttingCommand>
    {
        public UpdateGarmentServiceSubconCuttingCommandValidator()
        {
            RuleFor(r => r.Unit).NotNull();
            RuleFor(r => r.Unit.Id).NotEmpty().OverridePropertyName("Unit").When(w => w.Unit != null);
            RuleFor(r => r.Article).NotNull();
            RuleFor(r => r.RONo).NotNull();
            RuleFor(r => r.SubconDate).NotNull().GreaterThan(DateTimeOffset.MinValue);
            RuleFor(r => r.Comodity).NotNull();
            RuleFor(r => r.Comodity.Id).NotEmpty().OverridePropertyName("Comodity").When(w => w.Comodity != null);
            RuleFor(r => r.Items).NotEmpty().OverridePropertyName("Item");
            RuleFor(r => r.Items.Where(s => s.IsSave == true)).NotEmpty().WithMessage("Data Belum Ada yang dipilih").OverridePropertyName("ItemsCount").When(s => s.Items != null);
            RuleForEach(r => r.Items).SetValidator(new GarmentServiceSubconCuttingItemValueObjectValidator());
        }
    }

}