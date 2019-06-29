﻿using FluentValidation;
using Infrastructure.Domain.Commands;
using Manufactures.Domain.GarmentCuttingIns.ValueObjects;
using Manufactures.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Domain.GarmentCuttingIns.Commands
{
    public class UpdateGarmentCuttingInCommand : ICommand<GarmentCuttingIn>
    {
        public Guid Identity { get; private set; }
        public string CutInNo { get; set; }
        public string CuttingType { get; set; }
        public string RONo { get; set; }
        public string Article { get; set; }
        public UnitDepartment Unit { get; set; }
        public DateTimeOffset? CuttingInDate { get; set; }
        public double FC { get; set; }
        public List<GarmentCuttingInItemValueObject> Items { get; set; }

        public void SetIdentity(Guid id)
        {
            Identity = id;
        }
    }

    public class UpdateGarmentCuttingInCommandValidator : AbstractValidator<UpdateGarmentCuttingInCommand>
    {
        public UpdateGarmentCuttingInCommandValidator()
        {
            RuleFor(r => r.Unit).NotNull();
            RuleFor(r => r.Unit.Id).NotEmpty().OverridePropertyName("Unit").When(w => w.Unit != null);

            RuleFor(r => r.RONo).NotNull();
            RuleFor(r => r.CuttingInDate).NotNull().GreaterThan(DateTimeOffset.MinValue);
            RuleFor(r => r.FC).GreaterThan(0);
            RuleFor(r => r.Items).NotEmpty().OverridePropertyName("Item");
            RuleForEach(r => r.Items).SetValidator(new GarmentCuttingInItemValueObjectValidator());
        }
    }

}