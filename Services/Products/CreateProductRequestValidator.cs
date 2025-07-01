using App.Repositories.Products;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace App.Services.Products
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Name)
                //.NotNull().WithMessage("Ürün ismi gereklidir.")
                .NotEmpty().WithMessage("Ürün ismi gereklidir.")
                .Length(3, 10).WithMessage("Ürün ismi 3 ile 10 karakter arasında olmalıdır.")
                .Must(MustUniqueProductName).WithMessage("Ürün ismi veritabanında bulunmaktadır.");

            //price validation
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            //stock validation
            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("Ürün stoğu 1 ile 100 arasında olmalıdır.");
            

            //referance değerlerin default değeri null dır
            //value typeların default değeri 0 dır
        }

        public bool MustUniqueProductName(string name)
        {
            return !_productRepository.Where(x => x.Name == name).Any();
            //false ise hata var
            //true ise hata yok
        }
    }
}
