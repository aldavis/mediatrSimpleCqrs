using System.Linq;
using System.Threading.Tasks;
using application.Infrastructure.Persistence;
using domain.Model.ProductRoot;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;

namespace application.Products
{
    public class AddProductRequest : IRequest<AddProductResult>
    {
        public string PartNumber { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }

    public class AddProductResult
    {
        public int ProductId { get; set; }

        public string PartNumber { get; set; }

        public string Message { get; set; }
    }

    public class AddProductValidator : AbstractValidator<AddProductRequest>
    {
        //as an alternative fluent validation can be pushed up to the WebApi layer and with a little wiring just call ModelState.IsValid before calling mediatR
        private readonly IEntityFrameworkContext _context;

        public AddProductValidator(IEntityFrameworkContext context)
        {
            _context = context;

            RuleFor(x => x.PartNumber).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.PartNumber).Must(NotAlreadyExist).WithMessage("PartNumber Already Exists");
        }

        private bool NotAlreadyExist(string partNumber)
        {
            return !_context.Products.Any(x => x.PartNumber == partNumber);
        }
    }

    public class AddProductRequestPreProcessor : IRequestPreProcessor<AddProductRequest>
    {
        //a preprocessor should do more than just call validate, perhaps something like Validate,Authenticate, and Authorize 
        //would be more justifiable of having a preprocessor.

        private readonly IValidator<AddProductRequest> _validator;

        public AddProductRequestPreProcessor(IValidator<AddProductRequest> validator )
        {
            _validator = validator;
        }

        public async Task Process(AddProductRequest request)
        {
            await _validator.ValidateAndThrowAsync(request);
        }
    }

    public class AddProductRequestHandler : IAsyncRequestHandler<AddProductRequest, AddProductResult>
    {
        private readonly IEntityFrameworkContext _context;

        public AddProductRequestHandler(IEntityFrameworkContext context)
        {
            _context = context;
        }

        public async Task<AddProductResult> Handle(AddProductRequest request)
        {
            var product = new Product(request.PartNumber, request.Price);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return new AddProductResult {Message = "Product Added",PartNumber = product.PartNumber,ProductId = product.Id};
        }
    }

    public class AddProductPostProcessor :IRequestPostProcessor<AddProductRequest,AddProductResult>
    {
        //not really sure what a post processor could be used for other than logging or some generic operation
        public Task Process(AddProductRequest request, AddProductResult response)
        {
            response.Message += " Message appended to in Post Processor";

            return Task.FromResult(response);
        }
    }
}
