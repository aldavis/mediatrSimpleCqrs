using System;
using System.Threading.Tasks;
using MediatR;

namespace application.Orders.Add.Notification
{
    public class OrderAddedNotification:INotification
    {
        public OrderAddedNotification(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
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