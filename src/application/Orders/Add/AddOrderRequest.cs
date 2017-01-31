using MediatR;

namespace application.Orders.Add
{
    public class AddOrderRequest :IRequest<AddOrderResult>
    {
        public AddOrderRequest(string customerNumber, string partNumber,int quantity)
        {
            CustomerNumber = customerNumber;
            PartNumber = partNumber;
            Quantity = quantity;
        }

        public string CustomerNumber { get; }
        public string PartNumber { get; }
        public int Quantity { get; }


    }
}
