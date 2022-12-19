using ETicaret.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(p => p.UnitPrice)
                .NotEmpty()
                .GreaterThan(0);

            // Kategorisi 1 olanlarin Unit Price'i 10 dan buyuk olmali
            RuleFor(p => p.UnitPrice)
                .GreaterThanOrEqualTo(10)
                .When(p => p.CategoryId == 1);

            // Urun ismi A ile baslamali (StartWithA kendi metodumuz)
            //RuleFor(p => p.ProductName)
            //    .Must(StartWithA)
            //    .WithMessage("Ürünler A harfi ile başlamalı.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
