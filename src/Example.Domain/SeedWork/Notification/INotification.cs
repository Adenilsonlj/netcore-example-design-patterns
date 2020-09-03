using FluentValidation.Results;
using System.Collections.Generic;
using static Example.Domain.SeedWork.NotificationModel;

namespace Example.Domain.SeedWork
{
    public interface INotification
    {
        IReadOnlyCollection<NotificationModel> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message, ENotificationType notificationType);
        void AddNotification(string key, string message);
        void AddNotifications(IReadOnlyCollection<NotificationModel> notifications);
        void AddNotifications(IList<NotificationModel> notifications);
        void AddNotifications(ICollection<NotificationModel> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
