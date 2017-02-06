using System.Threading.Tasks;
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
            //still causing double hit, need to figure that part out
            string foo = "hit notifcation";
        }
    }

    public class OrderAddedSecondNotificationHandler : INotificationHandler<OrderAddedNotification>
    {
        public void Handle(OrderAddedNotification notification)
        {

            string foo = "hit second notifcation";
        }
    }
}
