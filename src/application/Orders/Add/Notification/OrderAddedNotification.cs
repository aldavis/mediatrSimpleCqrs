using System;
using System.Threading.Tasks;
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

    public class OrderAddedEmailNotificationHandler : IAsyncNotificationHandler<OrderAddedNotification>
    {
        Task IAsyncNotificationHandler<OrderAddedNotification>.Handle(OrderAddedNotification notification)
        {
            return Task.FromResult("ok");
        }
    }

    public class OrderAddedBusNotificationHandler : IAsyncNotificationHandler<OrderAddedNotification>
    {
        Task IAsyncNotificationHandler<OrderAddedNotification>.Handle(OrderAddedNotification notification)
        {
            return Task.FromResult("go");
        }
    }
}