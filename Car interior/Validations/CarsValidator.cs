﻿﻿using FluentValidation;
using Car_interior.Dtos;

namespace Car_interior.Validations
{
    public class CarsValidator : AbstractValidator<CarsDto>
    {
        public CarsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name)
               .NotEmpty()
               .MinimumLength(2)
               .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(10);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Description)
                .MaximumLength(100);
            RuleFor(x => x.ImageUrl).Must(LinkMustBeAUri).WithMessage("Inage url address must be valid.");
        }

        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }

    }
}
