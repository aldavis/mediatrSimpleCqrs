using MediatR;

namespace application.Orders.Add.Notification
{
    public class OrderAddedEmailNotificationHandler : INotificationHandler<OrderAddedNotification>
    {
        public void Handle(OrderAddedNotification notification)
        {
            //send out an email that the order was added
        }
    }
}