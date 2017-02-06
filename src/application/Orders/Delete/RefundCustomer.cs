using System.Data.Entity;
using System.Linq;
using application.Persistence;
using MediatR;

namespace application.Orders.Delete
{
    public class RefundCustomerRequest : IRequest<RefundCustomerResult>
    {
        public RefundCustomerRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
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


            var order = _context.Orders.Include(y => y.Customer).FirstOrDefault(x => x.Id == request.OrderId);

            var refundAmount = order.CalculateTotal();

            order.Customer.CreditAccount(refundAmount);

            _context.SaveChanges();

            return new RefundCustomerResult
            {
                CurrentAccountBalance = order.Customer.AccountBalance,
                RefundAmount = refundAmount
            };
        }
    }

    public class RefundCustomerResult
    {
        public decimal RefundAmount { get; set; }

        public decimal CurrentAccountBalance { get; set; }

    }
}
