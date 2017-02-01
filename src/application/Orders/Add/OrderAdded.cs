using MediatR;

namespace application.Orders.Add
{
    public class OrderAddedNotification:INotification
    {
        public OrderAddedNotification(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get; }
    }

    public class OrderAddedNotificationHandler : INotificationHandler<OrderAddedNotification>
    {
        public void Handle(OrderAddedNotification notification)
        {
            //TODO this appears to be getting called twice.....why???
            string foo = notification.OrderId;
        }
    }
}
