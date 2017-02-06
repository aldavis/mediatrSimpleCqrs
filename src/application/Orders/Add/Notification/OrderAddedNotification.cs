using MediatR;

namespace application.Orders.Add.Notification
{
    public class OrderAddedNotification:INotification
    {
        public OrderAddedNotification(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get; }
    }
}