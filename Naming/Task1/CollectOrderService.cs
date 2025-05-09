using Naming.Task1.ThirdParty;

namespace Naming.Task1
{
    public class CollectOrderService : IOrderService
    {
        private readonly ICollectionService _collectionService;
        private readonly INotificationManager _notificationManager;

        public CollectOrderService(ICollectionService collectionService, INotificationManager notificationManager)
        {
            _collectionService = collectionService;
            _notificationManager = notificationManager;
        }

        public void SubmitOrder(IOrder order)
        {
            if (_collectionService.IsEligibleForCollect(order))
            {
                _notificationManager.NotifyCustomer(Message.ReadyForCollect, NotificationLevel.Info); // 4 - info notification level
            }
            else
            {
                _notificationManager.NotifyCustomer(Message.ImpossibleToCollect, NotificationLevel.Critical); // 1 - critical notification level
            }
        }
    }
}
