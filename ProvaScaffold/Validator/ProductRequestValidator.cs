using FluentValidation;
using ProvaScaffold.Controllers.Dto;

namespace ProvaScaffold.Validator
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Il nome è obbligatorio");
            RuleFor(mp => mp.maxPrice).GreaterThanOrEqualTo(0).WithMessage("Il prezzo massimo deve essere maggiore o uguale a 0");
            RuleFor(mp => mp.minPrice).GreaterThanOrEqualTo(0).WithMessage("Il prezzo minimo deve essere maggiore o uguale a 0");
            RuleFor(mp => mp).Custom((mp, context) =>
            {
                if (mp.minPrice > mp.maxPrice)
                {
                    context.AddFailure("Il prezzo massimo non può essere minore del prezzo minimo");
                }
            });
            RuleFor(e => e.ElementInPage).GreaterThan(0).WithMessage("Gli elementi nella pagina devono essere più di 0");
            RuleFor(e => e.PageIndex).GreaterThan(0).WithMessage("L'indice della pagina non può essere inferiore ad 1");
        }
    }
}