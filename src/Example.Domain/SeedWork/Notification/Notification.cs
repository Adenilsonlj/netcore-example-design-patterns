using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using static Example.Domain.SeedWork.NotificationModel;

namespace Example.Domain.SeedWork
{
    public class Notification : INotification
    {
        private readonly List<NotificationModel> _notifications;

        public IReadOnlyCollection<NotificationModel> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public Notification()
        {
            _notifications = new List<NotificationModel>();
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new NotificationModel(key, message));
        }

        public void AddNotification(string key, string message, ENotificationType notificationType)
        {
            _notifications.Add(new NotificationModel(key, message, notificationType));
        }

        public void AddNotifications(IReadOnlyCollection<NotificationModel> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<NotificationModel> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<NotificationModel> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.PropertyName, error.ErrorMessage);
            }
        }

    }
}
