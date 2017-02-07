using application.Persistence;
using MediatR;

namespace application.Orders.Delete
{
    public class RefundCustomerRequest : IRequest<RefundCustomerResult>
    {
        public RefundCustomerRequest(int customerId,decimal amount)
        {
            CustomerId = customerId;
            Amount = amount;
        }

        public int CustomerId { get; }

        public decimal Amount { get; }
    }


    public class RefundCustomerResult
    {
        public decimal RefundAmount { get; set; }

        public decimal CurrentAccountBalance { get; set; }

    }

    public class RefundCustomerHandler : IRequestHandler<RefundCustomerRequest, RefundCustomerResult>
    {
        private readonly IEntityFrameworkContext _context;

        public RefundCustomerHandler(IEntityFrameworkContext context)
        {
            _context = context;
        }

        public RefundCustomerResult Handle(RefundCustomerRequest request)
        {

            var customer = _context.Customers.Find(request.CustomerId);

            customer.CreditAccount(request.Amount);

            _context.SaveChanges();

            return new RefundCustomerResult
            {
                CurrentAccountBalance = customer.AccountBalance,
                RefundAmount = request.Amount
            };
        }
    }
}
