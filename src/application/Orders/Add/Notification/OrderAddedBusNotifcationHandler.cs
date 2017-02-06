using MediatR;

namespace application.Orders.Add.Notification
{
    public class OrderAddedBusNotificationHandler : INotificationHandler<OrderAddedNotification>
    {
        public void Handle(OrderAddedNotification notification)
        {

            //put a message on the bus about the order being added
        }
    }
}
